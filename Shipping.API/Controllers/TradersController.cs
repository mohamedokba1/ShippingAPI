using Microsoft.AspNetCore.Mvc;
using Shipping.Services.IServices;
using Shipping.Services.Dtos;
using Microsoft.EntityFrameworkCore;
using Shipping.Services.Services;

namespace Shipping.API.Controllers
{
    [Route("api/traders")]
    [ApiController]
    public class TradersController : ControllerBase
    {
        private readonly ITraderService _traderService;
        private readonly ILogger<TradersController> _logger;
        public TradersController(ITraderService traderService, ILogger<TradersController> logger)
        {
            _traderService = traderService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<TraderResponseDto>? response =  await _traderService.GetAllTradersAsync();
            return Ok(response?.ToList());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
           TraderResponseDto? response = await _traderService.GetTraderByIdAsync(id);
           if(response == null)
                return NotFound();
           return Ok(response);
        }
        [HttpGet]
        [Route("email/{email}")]
        public async Task<ActionResult<long>> GetTraderIdByEmail(string email)
        {
            try
            {
                var traderId = await _traderService.GetTraderIdByEmail(email);
                return traderId;
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("paginated")]
        public async Task<ActionResult<PaginationResponse<TraderResponseDto>>> GetTraders([FromQuery] PaginationParameters paginationParameters)
        {
            var traders = _traderService.GetTradersPaginated();
            _logger.LogError("traders", traders);
            int totalRecords = await traders.CountAsync();

            List<TraderResponseDto>? listOfTrsders = await traders
                .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize)
                .ToListAsync();
            PaginationResponse<TraderResponseDto> result =
                new PaginationResponse<TraderResponseDto>()
                {
                    Data = listOfTrsders,
                    PageNo = paginationParameters.PageNumber,
                    PageSize = paginationParameters.PageSize,
                    TotalRecords = totalRecords
                };
            return Ok(result);
        }

        [HttpGet("filtered")]
        public async Task<IActionResult> GetFilteredTraders([FromQuery]string searchString)
        {
            if(string.IsNullOrEmpty(searchString) || string.IsNullOrWhiteSpace(searchString)) {
                return BadRequest();
            }
            IEnumerable<TraderResponseDto>? traders = await _traderService.GetFilteredTradersAsync(searchString);
            return Ok(traders?.ToList());
        }
        [HttpPost]
        public async Task<IActionResult> Addtrader(TraderAddDto traderAddDto)
        {
            TraderResponseDto? response = await _traderService.AddTraderAsync(traderAddDto);
            var uriBuilder = new UriBuilder(Request.Scheme, Request.Host.Host, Request.Host.Port ?? -1, "/api/traders/" + response?.TraderId.ToString());
            string createdUri = uriBuilder.ToString();
            if(response == null)
                return Problem();
            return Created(createdUri, response);
        }

        [HttpPut("{traderId}")]
        public async Task<IActionResult> UpdateTrader(string traderId, TraderUpdateDto traderUpdateDto)
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
        public async Task<IActionResult> DeleteTrader(string traderId)
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
