using Shipping.Repositories.Contracts;
using Shipping.Services.Dtos;
using Shipping.Services.IServices;

namespace Shipping.Services.Services;

public class TraderServices : ITraderService
{
    private readonly ITraderRepository _traderRepository;
    public TraderServices(ITraderRepository traderRepository)
    {
        _traderRepository = traderRepository;
    }

    public Task AddTraderAsync(TraderAddDto trader)
    {
        throw new NotImplementedException();
    }

    public Task DeleteTraderAsync(Guid trader_id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TraderResponseDto>?> GetAllTradersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<TraderResponseDto> GetTraderByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateTraderAsync(Guid trader_id, TraderUpdateDto trader)
    {
        throw new NotImplementedException();
    }
}
