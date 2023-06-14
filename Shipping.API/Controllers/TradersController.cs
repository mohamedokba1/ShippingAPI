using Microsoft.AspNetCore.Mvc;
using Shipping.Services.IServices;
using Shipping.Services.Dtos;

namespace Shipping.API.Controllers
{
    [Route("api/traders")]
    [ApiController]
    public class TradersController : ControllerBase
    {
        private readonly ITraderService _traderService;
        public TradersController(ITraderService traderService)
        {
            _traderService = traderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<TraderResponseDto>? response =  await _traderService.GetAllTradersAsync();
            return Ok(response?.ToList());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
           TraderResponseDto? response = await _traderService.GetTraderByIdAsync(id);
           if(response == null)
                return NotFound();
           return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Addtrader(TraderAddDto traderAddDto)
        {
            TraderResponseDto? response = await _traderService.AddTraderAsync(traderAddDto);
            var uriBuilder = new UriBuilder(Request.Scheme, Request.Host.Host, Request.Host.Port ?? -1, "/api/traders/" + response?.Trader_Id.ToString());
            string createdUri = uriBuilder.ToString();
            if(response == null)
                return Problem();
            return Created(createdUri, response);
        }

        [HttpPut("{traderId}")]
        public async Task<IActionResult> UpdateTrader(long traderId, TraderUpdateDto traderUpdateDto)
        {
            bool isUpdated = await _traderService.UpdateTraderAsync(traderId, traderUpdateDto);
            if(isUpdated)
            {
                TraderResponseDto? updatedTrader = await _traderService.GetTraderByIdAsync(traderId);
                return Ok(updatedTrader);
            }
            else
                return BadRequest();
        }

        [HttpDelete("{traderId}")]
        public async Task<IActionResult> DeleteTrader(long traderId)
        {
            TraderResponseDto? traderResponse = await _traderService.GetTraderByIdAsync(traderId);
            if(traderResponse == null) return NotFound();
            else
            {
                bool isDeleted = await _traderService.DeleteTraderAsync(traderId);
                if (isDeleted)
                {
                    return NoContent();
                }
                else
                {
                    return StatusCode(500);
                }
            }
        }
    }
}
