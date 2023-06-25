using Shipping.Entities.Domain.Models;
using Shipping.Services.Dtos;
using Shipping.Services.Dtos.SalesDtos;
using System.ComponentModel.DataAnnotations;

namespace Shipping.Services.IServices;

public interface ISalesService
{
    public Task<IEnumerable<SalesReadDtos>> GetAllSalesAsync();
    public Task<SalesReadDtos> GetSaleByIdAsync(long id);
    public Task<long?> GetSalesRepresentativeIdByEmail(string email);
    public Task<List<ValidationResult>?> AddUserAndSales(AddSalesDto sales);
    public Task UpdateAsync(long id ,SalesUpdateDtos sale);
    public Task DeleteAsync(long id);
    IQueryable<SalesReadDtos> GetSalesPaginated();

}
