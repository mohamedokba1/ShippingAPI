using Shipping.Entities.Domain.Models;
using Shipping.Repositories.Contracts;
using Shipping.Services.Dtos;
using Shipping.Services.IServices;
using Shipping.Services.Validations;

namespace Shipping.Services.Services;

public class OrderService : IOrderService
{
    public IOrderRepository orderRepository { get; }

    public OrderService(IOrderRepository _orderRepository)
    {
        orderRepository = _orderRepository;
    }

    public async Task AddAsync(OrderAddDto orderDto)
    {
        if (orderDto != null)
        {
            var order = new Order
            {
                CompanyBranch = orderDto.CompanyBranch,
                CustomerName = orderDto.CustomerName,
                PaymentMethod = orderDto.PaymentMethod,
                DefaultCost = orderDto.DefaultCost,
                ExtraWeightCost = orderDto.ExtraWeightCost,
                OrderDate = orderDto.OrderDate,
                salesRepresentativeId = orderDto.salesRepresentativeId,
                Products = orderDto.Products,
                shipping_type = orderDto.shipping_type,
                traderId = orderDto.traderId
            };
            ValidateModel.ModelValidation(order);
            await orderRepository.AddAsync(order);
            await orderRepository.SaveChangesAsync();
        }
    }
    public async Task DeleteAsync(long id)
    {
        var order = new Order
        {
            Order_Id = id
        };
        await orderRepository.DeleteAsync(order);
        await orderRepository.SaveChangesAsync();
    }
    public async Task<IEnumerable<OrderReadDto>> GetAllAsync()
    {
        var orders = await orderRepository.GetAllAsync();

        return orders.Select(o => new OrderReadDto
        {
            State = o.State,
            CompanyBranch = o.CompanyBranch,
            CustomerName = o.CustomerName,
            PaymentMethod = o.PaymentMethod,
            DefaultCost = o.DefaultCost,
            ExtraWeightCost = o.ExtraWeightCost,
            OrderDate = o.OrderDate,
            ShippingType = o.shipping_type,
        }
        );
    }
    public async Task<OrderReadDto> GetByIdAsync(long id)
    {
        var order = await orderRepository.GetByIdAsync(id);
        if (order != null)
        {
            return new OrderReadDto
            {
                State = order.State,
                CompanyBranch = order.CompanyBranch,
                CustomerName = order.CustomerName,
                PaymentMethod = order.PaymentMethod,
                DefaultCost = order.DefaultCost,
                ExtraWeightCost = order.ExtraWeightCost,
                OrderDate = order.OrderDate,
                ShippingType = order.shipping_type,

            };
        }
        return null;
    }
    public async Task UpdateAsync(OrderUpdateDto OrderUpdateDto, long id)
    {
        if (OrderUpdateDto != null)
        {
            var order = new Order
            {
                Order_Id = id,
                CompanyBranch = OrderUpdateDto.CompanyBranch,
                CustomerName = OrderUpdateDto.CustomerName,
                PaymentMethod = OrderUpdateDto.PaymentMethod,
                DefaultCost = OrderUpdateDto.DefaultCost,
                ExtraWeightCost = OrderUpdateDto.ExtraWeightCost,
                OrderDate = OrderUpdateDto.OrderDate,
                salesRepresentativeId = OrderUpdateDto.salesRepresentativeId,
                Products = OrderUpdateDto.Products,
                shipping_type = OrderUpdateDto.shipping_type,
                traderId = OrderUpdateDto.traderId,
                //IsDeleted = OrderUpdateDto.IsDeleted
            };
            ValidateModel.ModelValidation(order);
            await orderRepository.UpdateAsync(order);
            await orderRepository.SaveChangesAsync();
        }
    }
}
