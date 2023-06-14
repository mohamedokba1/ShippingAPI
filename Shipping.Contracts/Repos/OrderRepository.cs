using Microsoft.EntityFrameworkCore;
using Shipping.Entities;
using Shipping.Entities.Domain.Models;
using Shipping.Repositories.Contracts;

namespace Shipping.Repositories.Repos
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Set<Order>().Include(c=>c.Customers).ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(long id)
        {
            return await _context.Set<Order>().FirstOrDefaultAsync(order => order.Order_Id == id);
        }

        public async Task AddAsync(Order order)
        {
            await _context.Set<Order>().AddAsync(order);
        }

        public async Task UpdateAsync(Order order)
        {
            _context.Set<Order>().Update(order);
            await Task.CompletedTask;

        }

        public async Task DeleteAsync(Order order)
        {
            Order? result = await GetByIdAsync(order.Order_Id);
            if (result is not null)
            {
                //result.IsDeleted = true;
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
