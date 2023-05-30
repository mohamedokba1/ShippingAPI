using Shipping.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface ICustomerService
{
    public Task<IEnumerable<CustomerReadDto>> GetAllAsync();
    public Task<CustomerReadDto>? GetByIdAsync(Guid id);
    public Task AddAsync(CustomerAddDto customerAddDto);
    public Task UpdateAsync(CustomerUpdateDto customerUpdateDto, Guid id);
    public Task DeleteAsync(CustomerDeleteDto customerDeleteDto);
    public Task SaveChangesAsync();
}

