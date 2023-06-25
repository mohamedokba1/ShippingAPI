using Shipping.Entities.Domain.Models;

namespace Shipping.Repositories.Contracts;

public interface ISalesRepresentativeRepository
{
    Task AddAsync(SalesRepresentative sale);
    Task UpdateAsync(long id,SalesRepresentative? sale);
    Task DeleteAsync(long id);
    Task<IEnumerable<SalesRepresentative>> GetAllAsync();
    Task<SalesRepresentative?> GetByIdAsync(long id);
    Task<SalesRepresentative?> GetByEmailAsync(string email);
    Task saveChanges();
    IQueryable<SalesRepresentative> GetSalesRepresentativePaginated();
}
