﻿using Shipping.Entities.Domain.Models;

namespace Shipping.Repositories.Contracts;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetAllAsync();
    Task<Order?> GetByIdAsync(Guid id);
    Task AddAsync(Order order);
    Task UpdateAsync(Order order);
    Task DeleteAsync(Order order);
    Task SaveChangesAsync();
}
