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
                .Include(c => c.Customer)
                .Include(p => p.Products)
                .ToListAsync();
        }
        public async Task<Order?> GetOrderByIdAsync(long id)
        {
            return await _context.Set<Order>()
                .Include(order => order.Customer)
                .Include(order => order.Products)
                .FirstOrDefaultAsync(order => order.OrderId == id);
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

        public async Task<IEnumerable<Order>> GetAllTraderOrdersAsync(long traderId)
        {
            return await _context.Set<Order>()
                .Include(c => c.Customer)
                .Include(p => p.Products)
                .Where(order => order.TraderId == traderId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetAllSalesOrdersAsync(long salesId)
        {
            return await _context.Set<Order>()
                .Include(c => c.Customer)
                .Include(p => p.Products)
                .Where(order => order.SalesRepresentativeId == salesId)
                .ToListAsync();
        }

        public IQueryable<Order> GetOrderPaginated()
        {
            return _context.Set<Order>().AsQueryable();

        }
    }
}
