using AutoMapper;
using Shipping.Entities.Domain.Models;
using Shipping.Repositories.Contracts;
using Shipping.Services.Dtos;
using Shipping.Services.IServices;
using Shipping.Services.Validations;
using System.ComponentModel.DataAnnotations;

namespace Shipping.Services.Services;

public class TraderServices : ITraderService
{
    private readonly ITraderRepository _traderRepository;
    private readonly IMapper _mapper;
    public TraderServices(ITraderRepository traderRepository, IMapper mapper)
    {
        _traderRepository = traderRepository;
        _mapper = mapper;
    }

    public async Task<TraderResponseDto?> AddTraderAsync(TraderAddDto traderAddDto)
    {
        List<ValidationResult>? validationResult = ValidateModel.ModelValidation(traderAddDto);
        Trader newtrader = _mapper.Map<Trader>(traderAddDto);
        Trader? addedTrader =  await _traderRepository.AddTraderAsync(newtrader);
        if (addedTrader != null)
            return _mapper.Map<TraderResponseDto>(addedTrader);
        else
            return null;
    }

    public async Task<bool> DeleteTraderAsync(string trader_id)
    {
        Trader? trader = await _traderRepository.GetTraderByIdAsync(trader_id);
        if (trader != null)
        {
            await _traderRepository.DeleteTraderAsync(trader);
            return true;
        }
        else
            return false;
    }

    public async Task<IEnumerable<TraderResponseDto>?> GetAllTradersAsync()
    {
        IEnumerable<Trader>? traders = await _traderRepository.GetAllTradersAsync();
        List<TraderResponseDto> trdaersResponse = new List<TraderResponseDto>();
        foreach (Trader trader in traders)
        {
            trdaersResponse.Add(_mapper.Map<TraderResponseDto>(trader));
        }
        return trdaersResponse;
    }

    public async Task<TraderResponseDto> GetTraderByIdAsync(string id)
    {
        Trader? trader = await _traderRepository.GetTraderByIdAsync(id);
        return _mapper.Map<TraderResponseDto>(trader);
    }

    public async Task<bool> UpdateTraderAsync(string traderId, TraderUpdateDto traderUpdateDto)
    {
        Trader? trader = await _traderRepository.GetTraderByIdAsync(traderId);
        if (trader != null)
        {
            _mapper.Map(traderUpdateDto, trader);
            await _traderRepository.SaveChangesAsync();
            return true;
        }
        else { return false; }
    }
}
