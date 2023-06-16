using AutoMapper;
using AutoMapper.QueryableExtensions;
using AutoMapper.Configuration;
using Shipping.Entities.Domain.Models;
using Shipping.Repositories.Contracts;
using Shipping.Services.Dtos;
using Shipping.Services.IServices;
using Shipping.Services.Validations;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Shipping.Entities.Domain.Identity;
using Shipping.Repositories.Repos;
using System.Security.Claims;

namespace Shipping.Services.Services;

public class TraderServices : ITraderService
{
    private readonly ITraderRepository _traderRepository;
    private readonly IMapper _mapper;
    private readonly UserManager<ApplicationUser> _userManager;
    public TraderServices(ITraderRepository traderRepository, IMapper mapper, UserManager<ApplicationUser> userManager)
    {
        _traderRepository = traderRepository;
        _mapper = mapper;
        _userManager = userManager;
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

    public IQueryable<TraderResponseDto> GetTradersPaginated()
    {
        IQueryable traders = _traderRepository.GetTradersPaginated();
        return traders.ProjectTo<TraderResponseDto>(_mapper.ConfigurationProvider);
    }

    public async Task<IEnumerable<TraderResponseDto>> GetFilteredTradersAsync(string searchString)
    {
        IEnumerable<Trader>? traders =  await _traderRepository.GetFilteredTradersAsync(searchString);
        List<TraderResponseDto> trdaersResponse = new List<TraderResponseDto>();
        foreach (Trader trader in traders)
        {
            trdaersResponse.Add(_mapper.Map<TraderResponseDto>(trader));
        }
        return trdaersResponse;
    }

    public async Task AddTraderAsync2(TraderAddDto traderAddDto)
    {

            var user = new ApplicationUser
            {
                UserName = traderAddDto.TraderName,
                Email = traderAddDto.Email,
                PhoneNumber = traderAddDto.ContactNumber,
                PasswordHash = traderAddDto.Password
            };

            var Trader = new Trader
            {
                CompanyBranch = traderAddDto.CompanyBranch,
                CostPerRefusedOrder = traderAddDto.CostPerRefusedOrder,
                Address = traderAddDto.Address,
                User = user
            };
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.Id),
        new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, "Trader")
        };

            var claimResult = await _userManager.AddClaimsAsync(user, claims);

            await _userManager.CreateAsync(user, Trader.User.PasswordHash);
            await _traderRepository.AddTraderAsync(Trader);
            await _traderRepository.SaveChangesAsync();


    }
}
