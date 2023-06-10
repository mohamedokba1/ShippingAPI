using Shipping.Entities.Domain.Models;

namespace Shipping.Repositories.Contracts;

public interface ISalesRepresentativeRepository
{
    Task AddAsync(SalesRepresentative sale);
    Task UpdateAsync(Guid id,SalesRepresentative? sale);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<SalesRepresentative>> GetAllAsync();
    Task<SalesRepresentative>? GetByIdAsync(Guid id);
    Task saveChanges();

}
