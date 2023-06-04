using Shipping.Entities.Domain.Models;

namespace Shipping.Repositories.Contracts;

public interface ISalesRepresentativeRepository
{
    Task AddAsync(SalesRepresentative sale);
    Task UpdateAsync(SalesRepresentative sale);
    Task DeleteAsync(SalesRepresentative sale);
    Task<IEnumerable<SalesRepresentative>> GetAllAsync();
    Task<SalesRepresentative>? GetByIdAsync(int id);

}
