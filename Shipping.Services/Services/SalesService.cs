using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Shipping.Entities.Domain.Identity;
using Shipping.Entities.Domain.Models;
using Shipping.Repositories.Contracts;
using Shipping.Services.Dtos;
using Shipping.Services.Dtos.SalesDtos;
using Shipping.Services.IServices;
using System.Security.Claims;

namespace Shipping.Services.Services;

public class SalesService : ISalesService
{
    private readonly ISalesRepresentativeRepository _salesRepository;
    private readonly IMapper _mapper;
    private readonly UserManager<ApplicationUser> _userManager;
    public SalesService(ISalesRepresentativeRepository salesRepository,IMapper mapper, UserManager<ApplicationUser> userManager)
    {
        _salesRepository = salesRepository;
        _mapper = mapper;
        _userManager = userManager;
    }
    public async Task AddAsync(AddSalesDto sale)
    {
        var user = new ApplicationUser
        {
            UserName = sale.UserName,
            Email = sale.Email,
            PhoneNumber = sale.PhoneNumber
        };

        var salesRep = new SalesRepresentative
        {
            CompanyPercentage = sale.CompanyPercentage,
            Address=sale.Address,
            User = user
        };
        var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.Id),
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim(ClaimTypes.Role, "SalesRepresentative")
    };

        var claimResult = await _userManager.AddClaimsAsync(user, claims);
       
        await _userManager.CreateAsync(user, sale.Password);
        await _salesRepository.AddAsync(salesRep);
        await _salesRepository.saveChanges();
    }


    public async Task DeleteAsync(string id)
    {
        
        var sale = await _salesRepository.GetByIdAsync(id);
        if (sale != null)
        {
            
            await _salesRepository.DeleteAsync(sale.User.Id);
            _salesRepository.saveChanges();
        }
       
    }

    public async Task<IEnumerable<SalesReadDtos>> GetAllSalesAsync()
    {
        
        var sales= await _salesRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<SalesReadDtos>>(sales);
    }

    public async Task<SalesReadDtos> GetSaleByIdAsync(string id)
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

    public async Task<SalesReadDtos> GetSaleByEmailAsync(string email)
    {
        var sale = await _salesRepository.GetByEmailAsync(email);
        if (sale != null)
        {
            return _mapper.Map<SalesReadDtos>(sale);

        }
        else
        {
            return null;
        }
    }

    public async Task UpdateAsync(string id,SalesUpdateDtos sale)
    {
        var salToUpdate=await _salesRepository.GetByIdAsync(id);
        if(salToUpdate != null)
        {    
            salToUpdate.User.PhoneNumber = sale.PhoneNumber;
            salToUpdate.Address = sale.Address;
            salToUpdate.User.Email = sale.Email;
            salToUpdate.User.UserName = sale.Name;
            salToUpdate.User.PasswordHash = sale.Password;
            salToUpdate.CompanyPercentage = sale.CompanyPercentage;
            salToUpdate.User.UserName = sale.UserName;
            await _salesRepository.saveChanges();
        }
        
    }
}
