using Shipping.Entities.Models;

namespace Shipping.Repositories.Contracts;

public interface ITraderRepository
{
    Task<IEnumerable<Trader>> GetAllTtraders();
    Task<Trader?> GetTraderById(Guid trader_id);
    Task UpdateTrader(Trader trader);
    Task DeleteTrader(Trader trader);
    Task AddTrader(Trader trader);
}
