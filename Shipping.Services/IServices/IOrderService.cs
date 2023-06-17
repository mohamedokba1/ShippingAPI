using Shipping.Services.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Shipping.Services.IServices;

public interface IOrderService
{
    Task<IEnumerable<OrderResponseDto>> GetAllOrdersAsync(string email);
    Task<OrderResponseDto?> GetOrderByIdAsync(long id);
    Task<List<ValidationResult>?> AddOrderAsync(OrderAddDto orderAddDto, string userEmail);
    Task UpdateOrderAsync(long id, OrderUpdateDto orderUpdateDto);
    Task DeleteOrderAsync(long id);
}
