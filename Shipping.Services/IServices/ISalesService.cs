using Shipping.Entities.Domain.Models;
using Shipping.Services.Dtos;
using Shipping.Services.Dtos.SalesDtos;

namespace Shipping.Services.IServices;

public interface ISalesService
{
    public Task<IEnumerable<SalesReadDtos>> GetAllSalesAsync();
    public Task<SalesReadDtos> GetSaleByIdAsync(string id);
    public Task<SalesReadDtos> GetSaleByEmailAsync(string email);
    public Task AddAsync(AddSalesDto sale);
    public Task UpdateAsync(string id ,SalesUpdateDtos sale);
    public Task DeleteAsync(string id);
}
