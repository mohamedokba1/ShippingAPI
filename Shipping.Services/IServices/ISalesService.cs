using Shipping.Entities.Domain.Models;
using Shipping.Services.Dtos;
using Shipping.Services.Dtos.SalesDtos;

namespace Shipping.Services.IServices;

public interface ISalesService
{
    public Task<IEnumerable<SalesReadDtos>> GetAllSalesAsync();
    public Task<SalesReadDtos> GetSaleByIdAsync(long id);
    public Task<long> GetSalesRepresentativeIdByEmail(string email);
    public Task AddAsync(AddSalesDto sale);
    public Task UpdateAsync(long id ,SalesUpdateDtos sale);
    public Task DeleteAsync(long id);
}
