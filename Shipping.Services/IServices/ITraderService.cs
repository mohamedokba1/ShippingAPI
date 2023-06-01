using Shipping.Services.Dtos;

namespace Shipping.Services.IServices;

public interface ITraderService
{
    Task<IEnumerable<TraderResponseDto>?> GetAllTradersAsync();
    Task<TraderResponseDto> GetTraderByIdAsync(Guid id);
    Task AddTraderAsync(TraderAddDto trader);
    Task UpdateTraderAsync(Guid trader_id, TraderUpdateDto trader);
    Task DeleteTraderAsync(Guid trader_id);
}
