using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Shipping.Entities.Domain.Identity;
using Shipping.Entities.Domain.Models;
using Shipping.Repositories;
using Shipping.Repositories.Contracts;
using Shipping.Repositories.Repos;
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
    private readonly IBranchRepository _branchRepository;
    private readonly IGovermentRepository _governmentRepository;

    public SalesService(ISalesRepresentativeRepository salesRepository,
        IMapper mapper, 
        UserManager<ApplicationUser> userManager ,
        IBranchRepository branchRepository,
        IGovermentRepository governmentRepository)
    {
        _salesRepository = salesRepository;
        _mapper = mapper;
        _userManager = userManager;
        _branchRepository = branchRepository;
        this._governmentRepository = governmentRepository;
    }
    public async Task AddAsync(AddSalesDto sale)
    {
        var branches = await _branchRepository.GetRange(sale?.BranchesIds);
        var governments = await _governmentRepository.GetRange(sale?.GovernmentsIds);

        if(branches.Count()!=sale.BranchesIds.Count)
        {
            throw new Exception("these branches dont found ");
        }

        if (governments.Count()!=sale.GovernmentsIds.Count)
        {
            throw new Exception("these governments dont found ");

        }
        var user = new ApplicationUser
        {
            UserName = sale.UserName,
            Email = sale.Email,
            PhoneNumber = sale.PhoneNumber,
            PasswordHash=sale.Password
        };

        var salesRep = new SalesRepresentative
        {
            Name = sale.Name,
            Password=sale.Password,
            CompanyPercentage = sale.CompanyPercentage,
            DiscountType = sale.DiscountType,
            IsActive= sale.IsActive,
            Address = sale.Address,
            User = user,
            Branches = branches.ToList(), 
            Goverments = governments.ToList() ,
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

    public async Task<long?> GetSalesRepresentativeIdByEmail(string email)
    {
        var salesRepresentative = await _salesRepository.GetByEmailAsync(email);
        return salesRepresentative?.SalesRepresentativeId;
    }
    public async Task UpdateAsync(long id,SalesUpdateDtos sale)
    {
        var salToUpdate=await _salesRepository.GetByIdAsync(id);
        if(salToUpdate != null)
        {

            _mapper.Map(sale, salToUpdate);

            await _salesRepository.saveChanges();

        }
        else
        {
            throw new Exception("this employee is not found");
        }
        await _salesRepository.saveChanges();
        }

}

