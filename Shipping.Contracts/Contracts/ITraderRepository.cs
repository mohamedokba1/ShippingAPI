using Shipping.Entities.Domain.Models;

namespace Shipping.Repositories.Contracts;

public interface ITraderRepository
{
    Task<IEnumerable<Trader>> GetAllTradersAsync();
    Task<Trader?> GetTraderByIdAsync(string trader_id);
    Task DeleteTraderAsync(Trader trader);
    Task<Trader?> AddTraderAsync(Trader trader);
    Task UpdateAsync(Trader trader);
    Task SaveChangesAsync();
}
