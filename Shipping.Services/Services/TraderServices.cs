using Shipping.Entities.Models;
using Shipping.Repositories.Contracts;
using Shipping.Services.IServices;
using Shipping.Services.Validations;

namespace Shipping.Services.Services;

public class TraderServices : ITraderService
{
    private readonly ITraderRepository _traderRepository;
    public TraderServices(ITraderRepository traderRepository)
    {
        _traderRepository = traderRepository;
    }
    public void AddTrader(Trader trader)
    {

    }

    public void DeleteTrader(Guid trader_id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Trader> GetAllTraders()
    {
        throw new NotImplementedException();
    }

    public Trader GetTraderById(Guid id)
    {
        throw new NotImplementedException();
    }

    public void UpdateTrader(Guid trader_id, Trader trader)
    {
        throw new NotImplementedException();
    }
}
