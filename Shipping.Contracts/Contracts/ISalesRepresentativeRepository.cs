using Shipping.Entities.Domain.Models;

namespace Shipping.Repositories.Contracts;

public interface ISalesRepresentativeRepository
{
    Task AddAsync(SalesRepresentative sale);
    Task UpdateAsync(string id,SalesRepresentative? sale);
    Task DeleteAsync(string id);
    Task<IEnumerable<SalesRepresentative>> GetAllAsync();
    Task<SalesRepresentative>? GetByIdAsync(string id);
    Task<SalesRepresentative?> GetByEmailAsync(string email);
    Task saveChanges();

}
