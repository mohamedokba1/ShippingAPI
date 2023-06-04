using Shipping.Entities.Domain.Models;

namespace Shipping.Services.IServices;

public interface ISalesService
{
    public Task<IEnumerable<SalesRepresentative>> GetAllSalesAsync();
    public Task<SalesRepresentative> GetSaleByIdAsync(int id);
    public Task AddAsync(SalesRepresentative sale);
    public Task UpdateAsync(SalesRepresentative sale);
    public Task DeleteAsync(int id);
}
