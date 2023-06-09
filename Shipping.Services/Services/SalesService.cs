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
       return _salesRepository.AddAsync(AddedSale);
    }

    public async Task DeleteAsync(Guid id)
    {
        
        var sale = await _salesRepository.GetByIdAsync(id);
        if (sale != null)
        {
            
            await _salesRepository.DeleteAsync(sale);
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
            salToUpdate = _mapper.Map<SalesRepresentative>(salToUpdate);
             await _salesRepository.UpdateAsync(id,salToUpdate);
        }
        
    }
}
