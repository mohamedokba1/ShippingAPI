using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Shipping.Entities.Domain.Identity;
using Shipping.Entities.Domain.Models;
using Shipping.Repositories;
using Shipping.Repositories.Contracts;
using Shipping.Repositories.Repos;
using Shipping.Services.Dtos;
using Shipping.Services.Dtos.SalesDtos;
using Shipping.Services.IServices;
using Shipping.Services.Validations;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Shipping.Services.Services;

public class SalesService : ISalesService
{
    private readonly ISalesRepresentativeRepository _salesRepository;
    private readonly IMapper _mapper;
    private readonly UserManager<ApplicationUser> _userManager;

    public SalesService(ISalesRepresentativeRepository salesRepository,
        IMapper mapper,
        UserManager<ApplicationUser> userManager )
    {
        _salesRepository = salesRepository;
        _mapper = mapper;
        _userManager = userManager;
    }
    public async Task<List<ValidationResult>?> AddUserAndSales(AddSalesDto sales)
    {
        List<ValidationResult>? validationResult = ValidateModel.ModelValidation(sales);
        if (validationResult?.Count == 0)
        {
            ApplicationUser? checkuserEmail = await _userManager.FindByEmailAsync(sales.Email);
            if (checkuserEmail is null)
            {
                ApplicationUser? checkUserName = await _userManager.FindByNameAsync(sales.UserName);
                if (checkUserName is null)
                {
                    ApplicationUser user = _mapper.Map<ApplicationUser>(sales);
                    IdentityResult result = await _userManager.CreateAsync(user, sales.Password);
                    if (!result.Succeeded)
                    {
                        foreach (var error in result.Errors)
                        {
                            ValidationResult err = new ValidationResult(error.Description);
                            validationResult.Add(err);
                        }
                        return validationResult;
                    }
                    await _userManager.AddToRoleAsync(user, "salesrepresentative");
                    await _userManager.UpdateAsync(user);
                    ApplicationUser? addedUser = await _userManager.FindByEmailAsync(sales.Email);
                    sales.User = addedUser;
                }
                else
                {
                    validationResult.Add(new ValidationResult("usre name is already exist"));
                    return validationResult;
                }
            }
            else
            {
                validationResult.Add(new ValidationResult("Email is already exist"));
                return validationResult;
            }

            await _salesRepository.AddAsync(_mapper.Map<AddSalesDto, SalesRepresentative>(sales));
            return validationResult;
        }
        else
            return validationResult;
    }
    public async Task DeleteAsync(long id)
    {
        
        var sale = await _salesRepository.GetByIdAsync(id);
        if (sale != null)
        {
            
            await _salesRepository.DeleteAsync(id);
             await _salesRepository.saveChanges();
        }
        else
        {
            throw new Exception("this salesRepresentator is not found");
        }
       
    }

    public async Task<IEnumerable<SalesReadDtos>> GetAllSalesAsync()
    {
        var sales= await _salesRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<SalesReadDtos>>(sales);
    }

    public async Task<SalesReadDtos> GetSaleByIdAsync(long id)
    {
        var sale = await _salesRepository.GetByIdAsync(id);
        if(sale != null)
        {
            return _mapper.Map<SalesReadDtos>(sale);

        }
        else
        {
            return null;
        }
    }

    public IQueryable<SalesReadDtos> GetSalesPaginated()
    {
        IQueryable sales = _salesRepository.GetSalesRepresentativePaginated();
        return sales.ProjectTo<SalesReadDtos>(_mapper.ConfigurationProvider);
    }

    public async Task<long?> GetSalesRepresentativeIdByEmail(string email)
    {
        var salesRepresentative = await _salesRepository.GetByEmailAsync(email);
        return salesRepresentative?.SalesRepresentativeId;
    }
    public async Task UpdateAsync(long id, SalesUpdateDtos sale)
    {
        var salToUpdate = await _salesRepository.GetByIdAsync(id);
        if (salToUpdate != null)
        {

            _mapper.Map(sale, salToUpdate);

            await _salesRepository.saveChanges();

        }
        else
        {
            throw new Exception("this sales Representator is not found");
        }
    }

}

