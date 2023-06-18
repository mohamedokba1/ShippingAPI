using Shipping.Entities.Domain.Models;

namespace Shipping.Repositories.Contracts;

public interface ITraderRepository
{
    Task<IEnumerable<Trader>> GetAllTradersAsync();
<<<<<<< HEAD
    Task<Trader?> GetTraderByIdAsync(string trader_id);
=======
>>>>>>> 172b95938d700ce48f2dea7829dfb423d4db440b
    Task<Trader?> GetByEmailAsync(string email);
    Task<Trader?> GetTraderByIdAsync(long trader_id);
    Task DeleteTraderAsync(Trader trader);
    Task AddTraderAsync(Trader trader);
    Task UpdateAsync(Trader trader);
    Task SaveChangesAsync();
    IQueryable<Trader> GetTradersPaginated();
    Task<IEnumerable<Trader>> GetFilteredTradersAsync(string searchSrting);
}
