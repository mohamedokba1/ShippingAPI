using Shipping.Entities.Models;
namespace Shipping.Services.IServices;

public interface ITraderService
{
    IEnumerable<Trader> GetAllTraders();
    Trader GetTraderById(Guid id);
    void AddTrader(Trader trader);
    void UpdateTrader(Guid trader_id, Trader trader);
    void DeleteTrader(Guid trader_id);
}
