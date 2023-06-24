using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shipping.Services.Dtos;
using Shipping.Services.IServices;
using System.ComponentModel.DataAnnotations;

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
            IEnumerable<TraderResponseDto>? response = await _traderService.GetAllTradersAsync();
            return Ok(response?.ToList());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            TraderResponseDto? response = await _traderService.GetTraderByIdAsync(id);
            if (response == null)
                return NotFound();
            return Ok(response);
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
        public async Task<IActionResult> GetFilteredTraders([FromQuery] string searchString)
        {
            if (string.IsNullOrEmpty(searchString) || string.IsNullOrWhiteSpace(searchString))
            {
                return BadRequest();
            }
            IEnumerable<TraderResponseDto>? traders = await _traderService.GetFilteredTradersAsync(searchString);
            return Ok(traders?.ToList());
        }

        [HttpPost]
        public async Task<ActionResult> AddTrader(TraderAddDto traderAddDto)
        {
            var errors = await _traderService.AddUserAndTrader(traderAddDto);
            if (errors?.Count == 0)
                 return Ok(traderAddDto);
            return BadRequest(string.Join(", ", errors.Select(err => err.ErrorMessage)));
        }

        [HttpPut("{traderId}")]
        public async Task<IActionResult> UpdateTrader(long traderId, TraderUpdateDto traderUpdateDto)
        {
            List<ValidationResult>? errors = await _traderService.UpdateTraderAsync(traderId, traderUpdateDto);
            if (errors?.Count == 0)
            {
                TraderResponseDto? updatedTrader = await _traderService.GetTraderByIdAsync(traderId);
                return Ok(updatedTrader);
            }
            else
                return BadRequest(string.Join(", ", errors.Select(err => err.ErrorMessage)));
        }

        [HttpDelete("{traderId}")]
        public async Task<IActionResult> DeleteTrader(long traderId)
        {
            bool isDeleted = await _traderService.DeleteTraderAsync(traderId);
            if (isDeleted)
                return NoContent();

            return NotFound();
        }
    }
    }
