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

    public async Task DeleteAsync(Guid id)
    {
        
        var sale = await _salesRepository.GetByIdAsync(id);
        if (sale != null)
        {
            
            await _salesRepository.DeleteAsync(sale.SalesRepresentative_Id);
            _salesRepository.saveChanges();
        }
       
    }

    public async Task<IEnumerable<SalesReadDtos>> GetAllSalesAsync()
    {
        
        var sales= await _salesRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<SalesReadDtos>>(sales);
    }

    public async Task<SalesReadDtos> GetSaleByIdAsync(Guid id)
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

    public async Task UpdateAsync(Guid id,SalesUpdateDtos sale)
    {
        var salToUpdate=await _salesRepository.GetByIdAsync(id);
        if(salToUpdate != null)
        {
            //salToUpdate = _mapper.Map<SalesRepresentative>(salToUpdate);
            //salToUpdate = new SalesRepresentative()
            //{
            //    SalesRepresentative_Id = salToUpdate.SalesRepresentative_Id,
            //    Address = salToUpdate.Address,
            //    Name = salToUpdate.Name,
            //    PhoneNumber = salToUpdate.PhoneNumber,
            //    Password = salToUpdate.Password,
            //    CompanyPercentage = salToUpdate.CompanyPercentage,
            //    Email = salToUpdate.Email
            //};
             
            salToUpdate.PhoneNumber = sale.PhoneNumber;
            salToUpdate.Address = sale.Address;
            salToUpdate.Email=sale.Email;
            salToUpdate.Name = sale.Name;
            salToUpdate.Password = sale.Password;
            salToUpdate.CompanyPercentage = sale.CompanyPercentage;
            salToUpdate.UserName = sale.UserName;
            await _salesRepository.saveChanges();
        }
        
    }
}
