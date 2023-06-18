using Shipping.Entities.Domain.Models;

public interface IBranchRepository
{
    Task<IEnumerable<Branch>> GetAllAsync();
    Task<Branch> GetByIdAsync(int id);
    Task AddAsync(Branch entity);
    Task UpdateAsync(Branch entity);
    Task DeleteAsync(Branch entity);
    Task SaveChangesAsync();
}