using Shipping.Services.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Shipping.Services.IServices;

public interface ITraderService
{
    Task<IEnumerable<TraderResponseDto>?> GetAllTradersAsync();
    Task<TraderResponseDto> GetTraderByIdAsync(long id);
    Task<long?> GetTraderIdByEmailAsync(string traderEmail);
    Task<List<ValidationResult>?> AddUserAndTrader(TraderAddDto traderAddDto);
    Task<List<ValidationResult>?> UpdateTraderAsync(long trader_id, TraderUpdateDto traderUpdateDto);
    Task<bool> DeleteTraderAsync(long trader_id);
    IQueryable<TraderResponseDto> GetTradersPaginated();
    Task<IEnumerable<TraderResponseDto>> GetFilteredTradersAsync(string searchString);
}