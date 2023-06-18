using Shipping.Entities.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IBranchRepository
{
     public  interface IBranchRepository
    {
    Task<IEnumerable<Branch>> GetAllAsync();
    Task<Branch> GetByIdAsync(int id);
    Task AddAsync(Branch entity);
    Task UpdateAsync(Branch entity);
    Task DeleteAsync(Branch entity);
    Task SaveChangesAsync();
}