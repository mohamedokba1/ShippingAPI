using Shipping.Entities.Domain.Models;

namespace Shipping.Repositories.Contracts;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetAllOrdersAsync();
    Task<IEnumerable<Order>> GetAllTraderOrdersAsync(long traderId);
    Task<IEnumerable<Order>> GetAllSalesOrdersAsync(long salesId);
    Task<Order?> GetOrderByIdAsync(long id);
    Task<Order?> AddOrderAsync(Order order);
    Task UpdateOrderAsync(Order order);
    Task<bool> DeleteOrderAsync(Order order);
    Task SaveChangesAsync();
    IQueryable<Order> GetOrderPaginated();
}
