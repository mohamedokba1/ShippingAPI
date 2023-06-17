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

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _context.Set<Order>()
                .Include(c => c.Customers)
                .ToListAsync();
        }
        public async Task<IEnumerable<Order>> GetAllTraderOrdersAsync(Trader trader)
        {
            return await _context.Set<Order>()
                .Include(c=> c.Customers)
                .Where(order => order.Trader == trader)
                .ToListAsync();
        }
        public async Task<IEnumerable<Order>> GetAllSalesOrdersAsync(SalesRepresentative salesRepresentative)
        {
            return await _context.Set<Order>()
                .Include(c => c.Customers)
                .Where(order => order.SalesRepresentative == salesRepresentative)
                .ToListAsync();
        }

        public async Task<Order?> GetOrderByIdAsync(long id)
        {
            return await _context.Set<Order>().FirstOrDefaultAsync(order => order.OrderId == id);
        }

        public async Task<Order?> AddOrderAsync(Order order)
        {
            await _context.Set<Order>().AddAsync(order);
            await SaveChangesAsync();
            return order;
        }

        public async Task UpdateOrderAsync(Order order)
        {
            _context.Set<Order>().Update(order);
            await Task.CompletedTask;
        }

        public async Task<bool> DeleteOrderAsync(Order order)
        {
            Order? result = await GetOrderByIdAsync(order.OrderId);
            if (result is not null)
            {
                result.IsDeleted = true;
                await SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
