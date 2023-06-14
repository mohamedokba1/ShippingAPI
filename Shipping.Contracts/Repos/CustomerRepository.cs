﻿using Shipping.Entities;
using Shipping.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Shipping.Repositories;
using Shipping.Entities.Domain.Models;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _context;
    public CustomerRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _context.Set<Customer>().Include(o=>o.Orders).ToListAsync();
    }

    public async Task<Customer>? GetByIdAsync(Guid id)
    {
         return await _context.Set<Customer>().FindAsync(id);
    }
    public async Task AddAsync(Customer entity)
    {
        await _context.AddAsync(entity);
    }
    public async Task UpdateAsync(Customer entity)
    {
        _context.Update(entity);
        await Task.CompletedTask;
    }
    public async Task DeleteAsync(Customer entity)
    {
        _context.Set<Customer>().Remove(entity);
        await Task.CompletedTask;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<List<Customer>> GetCustomersByIds(List<Guid> customerIds)
    {
        return await _context.Customers
            .Where(c => customerIds.Contains(c.Customer_Id))
            .ToListAsync();
    }

}
