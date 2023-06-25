using AutoMapper;
using AutoMapper.QueryableExtensions;
using Shipping.Entities.Domain.Models;
using Shipping.Repositories.Contracts;
using Shipping.Services.Dtos;
using Shipping.Services.IServices;
using Shipping.Services.Validations;
using System.ComponentModel.DataAnnotations;
using Shipping.Entities.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace Shipping.Services.Services;

public class TraderServices : ITraderService
{
    private readonly ITraderRepository _traderRepository;
    private readonly IMapper _mapper;
    private readonly UserManager<ApplicationUser> _userManager;
    public TraderServices(
        ITraderRepository traderRepository,
        IMapper mapper,
        UserManager<ApplicationUser> userManager)
    {
        _traderRepository = traderRepository;
        _mapper = mapper;
        _userManager = userManager;
    }
    public async Task<List<ValidationResult>?> AddUserAndTrader(TraderAddDto traderAddDto)
    {
        List<ValidationResult>? validationResult = ValidateModel.ModelValidation(traderAddDto);
        if (validationResult?.Count == 0)
        {
            ApplicationUser? checkuserEmail = await _userManager.FindByEmailAsync(traderAddDto.Email);
            if (checkuserEmail is null)
            {
                ApplicationUser? checkUserName = await _userManager.FindByNameAsync(traderAddDto.UserName);
                if (checkUserName is null)
                {
                    ApplicationUser user = _mapper.Map<ApplicationUser>(traderAddDto);
                    IdentityResult result = await _userManager.CreateAsync(user, traderAddDto.Password);
                    if (!result.Succeeded)
                    {
                        foreach (var error in result.Errors)
                        {
                            ValidationResult err = new ValidationResult(error.Description);
                            validationResult.Add(err);
                        }
                        return validationResult;
                    }
                    await _userManager.AddToRoleAsync(user, "trader");
                    await _userManager.UpdateAsync(user);
                    ApplicationUser? addedUser = await _userManager.FindByEmailAsync(traderAddDto.Email);
                    traderAddDto.User = addedUser;
                }
                else
                {
                    validationResult.Add(new ValidationResult("Username is already exist"));
                    return validationResult;
                }
            }
            else
            {
                validationResult.Add(new ValidationResult("Email is already exist"));
                return validationResult;
            }

            await _traderRepository.AddTraderAsync(_mapper.Map<TraderAddDto, Trader>(traderAddDto));
            return validationResult;
        }
        else
            return validationResult;
    }

    public async Task<bool> DeleteTraderAsync(long trader_id)
    {
        Trader? trader = await _traderRepository.GetTraderByIdAsync(trader_id);
        if (trader != null)
        {
            await _traderRepository.DeleteTraderAsync(trader);
            ApplicationUser? user = await _userManager.FindByEmailAsync(trader.Email);
            if (user != null)
                await _userManager.DeleteAsync(user);
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

    public async Task<TraderResponseDto> GetTraderByIdAsync(long id)
    {
        Trader? trader = await _traderRepository.GetTraderByIdAsync(id);
        return _mapper.Map<TraderResponseDto>(trader);
    }

    public async Task<List<ValidationResult>?> UpdateTraderAsync(long traderId, TraderUpdateDto traderUpdateDto)
    {
        List<ValidationResult>? validationResults = ValidateModel.ModelValidation(traderUpdateDto);
        if (validationResults?.Count == 0)
        {
            var checkUserName = await _userManager.FindByNameAsync(traderUpdateDto.UserName);
            if (checkUserName == null)
            {
                Trader? trader = await _traderRepository.GetTraderByIdAsync(traderId);
                if (trader != null)
                {
                    ApplicationUser? user = await _userManager.FindByEmailAsync(trader.User.Email);
                    _mapper.Map<TraderUpdateDto, ApplicationUser>(traderUpdateDto, user);
                    await _userManager.UpdateAsync(user);
                    _mapper.Map(traderUpdateDto, trader);
                    await _traderRepository.SaveChangesAsync();
                }
            }
            return validationResults;
        }
        else
            return validationResults;
    }

    public IQueryable<TraderResponseDto> GetTradersPaginated()
    {
        IQueryable traders = _traderRepository.GetTradersPaginated();
        return traders.ProjectTo<TraderResponseDto>(_mapper.ConfigurationProvider);
    }

    public async Task<IEnumerable<TraderResponseDto>> GetFilteredTradersAsync(string searchString)
    {
        IEnumerable<Trader>? traders = await _traderRepository.GetFilteredTradersAsync(searchString);
        List<TraderResponseDto> trdaersResponse = new List<TraderResponseDto>();
        foreach (Trader trader in traders)
        {
            trdaersResponse.Add(_mapper.Map<TraderResponseDto>(trader));
        }
        return trdaersResponse;
    }

    public async Task<long?> GetTraderIdByEmailAsync(string email)
    {
        Trader? trader = await _traderRepository.GetTraderByEmailAsync(email);
        if (trader == null)
            return null;

        return trader.TraderId;
    }

 
}
