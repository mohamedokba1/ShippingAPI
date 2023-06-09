using Shipping.Entities.Domain.Models;
using Shipping.Services.Dtos;
using Shipping.Services.Dtos.SalesDtos;

namespace Shipping.Services.IServices;

public interface ISalesService
{
    public Task<IEnumerable<SalesReadDtos>> GetAllSalesAsync();
    public Task<SalesReadDtos> GetSaleByIdAsync(Guid id);
    public Task AddAsync(AddSalesDto sale);
    public Task UpdateAsync(Guid id ,SalesUpdateDtos sale);
    public Task DeleteAsync(Guid id);
}
