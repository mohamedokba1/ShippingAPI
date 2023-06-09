using Shipping.Entities.Domain.Models;

namespace Shipping.Repositories.Contracts;

public interface IPrivellageRepository
{
    Task<IEnumerable<Privellge>> GetAllAsync();
    Task<Privellge> GetByIdAsync(Guid id);
    Task AddAsync(Privellge privellge);
    Task UpdateAsync(Privellge privellge);
    Task DeleteAsync(Privellge privellge);
    Task SaveChangesAsync();
}
