using Shipping.Entities.Domain.Models;
using Shipping.Services.Dtos;
using Shipping.Services.Dtos.SalesDtos;

namespace Shipping.Services.IServices;

public interface ISalesService
{
    Task<IEnumerable<SalesReadDtos>> GetAllSalesAsync();
    Task<SalesReadDtos> GetSaleByIdAsync(string id);
    Task<long?> GetSalesRepresentativeIdByEmail(string email);
    Task AddAsync(AddSalesDto sale);
    Task UpdateAsync(string id ,SalesUpdateDtos sale);
    Task DeleteAsync(string id);
}
