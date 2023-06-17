using Shipping.Entities.Domain.Models;

namespace Shipping.Repositories.Contracts;

public interface ITraderRepository
{
    Task<IEnumerable<Trader>> GetAllTradersAsync();
    Task<Trader?> GetTraderByIdAsync(string trader_id);
    Task<Trader?> GetByEmailAsync(string email);
    Task DeleteTraderAsync(Trader trader);
    Task<Trader?> AddTraderAsync(Trader trader);
    Task UpdateAsync(Trader trader);
    Task SaveChangesAsync();
    IQueryable<Trader> GetTradersPaginated();
    Task<IEnumerable<Trader>> GetFilteredTradersAsync(string searchSrting);
}
