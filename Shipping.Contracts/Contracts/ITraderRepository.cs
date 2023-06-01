using Shipping.Entities.Models;

namespace Shipping.Repositories.Contracts;

public interface ITraderRepository
{
    Task<IEnumerable<Trader>> GetAllTradersAsync();
    Task<Trader?> GetTraderByIdAsync(Guid trader_id);
    Task UpdateTraderASync(Guid trderId, Trader trader);
    Task DeleteTraderAsync(Trader trader);
    Task AddTraderAsync(Trader trader);
}
