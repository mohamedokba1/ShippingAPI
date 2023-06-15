using Shipping.Services.Dtos;

namespace Shipping.Services.IServices;

public interface ITraderService
{
    Task<IEnumerable<TraderResponseDto>?> GetAllTradersAsync();
    Task<TraderResponseDto> GetTraderByIdAsync(long id);
    Task<TraderResponseDto?> AddTraderAsync(TraderAddDto traderAddDto);
    Task<bool> UpdateTraderAsync(long trader_id, TraderUpdateDto traderUpdateDto);
    Task<bool> DeleteTraderAsync(long trader_id);
    IQueryable<TraderResponseDto> GetTradersPaginated();
    Task<IEnumerable<TraderResponseDto>> GetFilteredTradersAsync(string searchString);
}
