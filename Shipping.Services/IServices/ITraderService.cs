using Shipping.Services.Dtos;

namespace Shipping.Services.IServices;

public interface ITraderService
{
    Task<IEnumerable<TraderResponseDto>?> GetAllTradersAsync();
    Task<TraderResponseDto> GetTraderByIdAsync(string id);
    Task<TraderResponseDto?> AddTraderAsync(TraderAddDto traderAddDto);
    Task AddTraderAsync2(TraderAddDto traderAddDto);
    Task<bool> UpdateTraderAsync(string trader_id, TraderUpdateDto traderUpdateDto);
    Task<bool> DeleteTraderAsync(string trader_id);
    IQueryable<TraderResponseDto> GetTradersPaginated();
    Task<IEnumerable<TraderResponseDto>> GetFilteredTradersAsync(string searchString);
}
