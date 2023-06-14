﻿using Shipping.Entities.Domain.Models;
using System.Net.Sockets;

namespace Shipping.Repositories.Contracts;

public interface ICustomerRepository
{
    Task<IEnumerable<Customer>> GetAllAsync();
    Task<Customer>? GetByIdAsync(Guid id);
    Task AddAsync(Customer entity);
    Task UpdateAsync(Customer entity);
    Task DeleteAsync(Customer entity);
    Task SaveChangesAsync();
    Task<List<Customer>> GetCustomersByIds(List<Guid> customerIds);
}
