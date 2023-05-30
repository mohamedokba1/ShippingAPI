using Microsoft.EntityFrameworkCore;
using Shipping.Entities;
using Shipping.Entities.Models;
using Shipping.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Repositories.Repos
{
    public class OrderRepository : IOrderRepository
    {
        public ApplicationDbContext context { get; }

        public OrderRepository(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await context.Set<Order>().ToListAsync();
        }

        public async Task<Order> GetByIdAsync(Guid id)
        {
            return await context.Set<Order>().FindAsync(id);
        }

        public async Task AddAsync(Order order)
        {
            await context.Set<Order>().AddAsync(order);
        }

        public async Task UpdateAsync(Order order)
        {
            context.Set<Order>().Update(order);
            await Task.CompletedTask;

        }

        public async Task DeleteAsync(Order order)
        {
            context.Set<Order>().Remove(order);
            await Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
