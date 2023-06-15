using AutoMapper;
using Shipping.Entities.Domain.Models;
using Shipping.Repositories.Contracts;
using Shipping.Services.Dtos;
using Shipping.Services.Dtos.SalesDtos;
using Shipping.Services.IServices;

namespace Shipping.Services.Services;

public class SalesService : ISalesService
{
    private readonly ISalesRepresentativeRepository _salesRepository;
    private readonly IMapper _mapper;
    public SalesService(ISalesRepresentativeRepository salesRepository,IMapper mapper)
    {
        _salesRepository = salesRepository;
        _mapper = mapper;
    }
    public Task AddAsync(AddSalesDto sale)
    {
        var AddedSale=_mapper.Map<SalesRepresentative>(sale);
       _salesRepository.AddAsync(AddedSale);
        _salesRepository.saveChanges();
        return Task.CompletedTask;
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
