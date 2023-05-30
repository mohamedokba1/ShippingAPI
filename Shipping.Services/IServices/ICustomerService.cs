using Shipping.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface ICustomerService
{
    public Task<IEnumerable<Customer>> GetAllAsync();
    public Task<Customer>? GetByIdAsync(Guid id);
    public Task AddAsync(Customer customer);
    public Task UpdateAsync(Customer customer, Guid id);
    public Task DeleteAsync(Guid id);
    public Task SaveChangesAsync();
}

