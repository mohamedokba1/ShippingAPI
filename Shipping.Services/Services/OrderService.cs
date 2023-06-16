using Shipping.Entities.Domain.Models;
using Shipping.Repositories.Contracts;
using Shipping.Services.Dtos;
using Shipping.Services.IServices;
using Shipping.Services.Validations;

namespace Shipping.Services.Services;

public class OrderService : IOrderService
{
    public IOrderRepository orderRepository { get; }
    public ICustomerRepository _customerRepository { get; }


    public OrderService(IOrderRepository _orderRepository, ICustomerRepository customerRepository)
    {
        orderRepository = _orderRepository;
        _customerRepository = customerRepository;
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
                shipping_type = orderDto.shipping_type,
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

        if (orders == null)
        {
            return null;
        }

        var orderReadDtos = new List<OrderReadDto>();

        foreach (var order in orders)
        {
            foreach (var customer in order.Customers)
            {
                var orderReadDto = new OrderReadDto
                {
                    OrderId = order.Order_Id,
                    State = order.State,
                    PaymentMethod = order.PaymentMethod,
                    OrderDate = order.OrderDate,
                    ExtraWeightCost = order.ExtraWeightCost,
                    CompanyBranch = order.CompanyBranch,
                    DefaultCost = order.DefaultCost,
                    CustomerId = customer.Customer_Id,
                    City = customer.City,
                    Government = customer.Goverment,
                    CustomerName = customer.Name,
                    ShippingType = order.shipping_type,
                    TraderId = order.TraderId,
                    SalesRepresentativeId = order.SalesRepresentativeId
                };

                orderReadDtos.Add(orderReadDto);
            }
        }

        return orderReadDtos;

    }

    public async Task<OrderResponseDto> GetByIdAsync(long id)
    {
        var order = await orderRepository.GetByIdAsync(id);
        if (order != null)
        {
            return new OrderResponseDto
            {
                Id=order.Order_Id,
                State = order.State,
                CompanyBranch = order.CompanyBranch,
                CustomerName = order.CustomerName,
                PaymentMethod = order.PaymentMethod,
                DefaultCost = order.DefaultCost,
                ExtraWeightCost = order.ExtraWeightCost,
                OrderDate = order.OrderDate,
                shipping_type = order.shipping_type,

            };
        }
        return null;
    }
    public async Task UpdateAsync(OrderUpdateDto OrderUpdateDto, long id)
    {
        if (OrderUpdateDto != null)
        {
            var existingOrder = await orderRepository.GetByIdAsync(id);

            existingOrder.State= OrderUpdateDto.State ;
            existingOrder.CompanyBranch= OrderUpdateDto.CompanyBranch ;
            existingOrder.CustomerName = OrderUpdateDto.CustomerName;
            existingOrder.PaymentMethod = OrderUpdateDto.PaymentMethod;
            existingOrder.DefaultCost = OrderUpdateDto.DefaultCost;
            existingOrder.ExtraWeightCost = OrderUpdateDto.ExtraWeightCost;
            existingOrder.OrderDate = OrderUpdateDto.OrderDate;
            existingOrder.shipping_type = OrderUpdateDto.shipping_type;


            ValidateModel.ModelValidation(existingOrder);
            await orderRepository.UpdateAsync(existingOrder);
            await orderRepository.SaveChangesAsync();
        }
    }
}
