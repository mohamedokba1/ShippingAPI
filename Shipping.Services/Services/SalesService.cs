using Shipping.Entities.Domain.Models;
using Shipping.Repositories.Contracts;
using Shipping.Services.IServices;

namespace Shipping.Services.Services;

public class SalesService : ISalesService
{
    private readonly ISalesRepresentativeRepository _salesRepository;
    public SalesService(ISalesRepresentativeRepository salesRepository)
    {
        _salesRepository = salesRepository;
    }
    public Task AddAsync(SalesRepresentative sale)
    {
       return _salesRepository.AddAsync(sale);
    }

    public async Task DeleteAsync(int id)
    {
        var sale = await _salesRepository.GetByIdAsync(id);
        if (sale != null)
        {
            await _salesRepository.DeleteAsync(sale);
        }
    }

    public Task<IEnumerable<SalesRepresentative>> GetAllSalesAsync()
    {
        return _salesRepository.GetAllAsync();
    }

    public Task<SalesRepresentative> GetSaleByIdAsync(int id)
    {
        return _salesRepository.GetByIdAsync(id);
    }

    public Task UpdateAsync(SalesRepresentative sale)
    {
        return _salesRepository.UpdateAsync(sale);
    }
}
