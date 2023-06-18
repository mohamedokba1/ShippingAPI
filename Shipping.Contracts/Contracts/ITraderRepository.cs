using Shipping.Entities.Domain.Models;

namespace Shipping.Repositories.Contracts;

public interface ITraderRepository
{
    Task<IEnumerable<Trader>> GetAllTradersAsync();
    Task<Trader?> GetTraderByEmailAsync(string email);
    Task<Trader?> GetTraderByIdAsync(long trader_id);
    Task DeleteTraderAsync(Trader trader);
    Task AddTraderAsync(Trader trader);
    Task UpdateAsync(Trader trader);
    Task SaveChangesAsync();
    IQueryable<Trader> GetTradersPaginated();
    Task<IEnumerable<Trader>> GetFilteredTradersAsync(string searchSrting);
}
