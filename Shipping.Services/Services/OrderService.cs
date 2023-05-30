using Shipping.Entities.Models;
using Shipping.Repositories.Contracts;
using Shipping.Repositories.Repos;
using Shipping.Services.Dtos.OrderDtos;
using Shipping.Services.IServices;
using Shipping.Services.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Services.Services;

public class OrderService : IOrderService
{
    public  IOrderRepository orderRepository { get; }

    public OrderService(IOrderRepository _orderRepository)
    {
        orderRepository = _orderRepository;
    }


    public async Task AddAsync(OrderDto orderDto)
    {
        if(orderDto != null)
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

    public async Task DeleteAsync(Guid id)
    {  
            var order = new Order
            {
                Order_Id = id
            };
            await orderRepository.DeleteAsync(order);
            await orderRepository.SaveChangesAsync();
        }


    public  async Task<IEnumerable<OrderReadDto>> GetAllAsync()
{
        var orders = await orderRepository.GetAllAsync();

        return orders.Select(o=> new OrderReadDto
        {
            State = o.State,
            CompanyBranch= o.CompanyBranch,
            CustomerName= o.CustomerName,
            PaymentMethod= o.PaymentMethod,
            DefaultCost = o.DefaultCost,
            ExtraWeightCost= o.ExtraWeightCost,
            OrderDate = o.OrderDate,
            ShippingType = o.shipping_type,
        }
        );
    }

    public async Task<OrderReadDto> GetByIdAsync(Guid id)
    {
        var order = await orderRepository.GetByIdAsync(id);
        if(order != null)
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


    public async Task UpdateAsync(OrderDto orderDto, Guid id)
    {
        if (orderDto != null)
        {
            var order = new Order
            {
                Order_Id = id,
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
            await orderRepository.UpdateAsync(order);
            await orderRepository.SaveChangesAsync();
        }
    }


}
