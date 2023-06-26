using Shipping.Entities.Domain.Models;

namespace Shipping.Repositories;

public interface IBranchRepository
{
    Task<IEnumerable<Branch>> GetAllAsync();
    Task<Branch?> GetByIdAsync(int id);
    Task AddAsync(Branch entity);
    Task UpdateAsync(Branch entity);
    Task DeleteAsync(Branch entity);
    Task SaveChangesAsync();
    Task<IEnumerable<Branch?>> GetRange(List<int> ids);
    IQueryable<Branch> GetBranchPaginated();
}