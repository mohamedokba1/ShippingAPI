using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Shipping.Entities.Domain.Identity;
using Shipping.Entities.Domain.Models;
using Shipping.Repositories.Contracts;
using Shipping.Services.Dtos;
using Shipping.Services.IServices;
using Shipping.Services.Validations;
using System.ComponentModel.DataAnnotations;

namespace Shipping.Services.Services;

public class OrderService 
{
    private readonly IOrderRepository _orderRepository;
    private readonly ITraderService _traderService;
    private readonly IMapper _mapper;

    public OrderService(
        IOrderRepository orderRepository,
        ITraderService traderService,
        IMapper mapper)
    {
        _orderRepository = orderRepository;
        _traderService = traderService;
        _mapper = mapper;
    }

    public async Task<List<ValidationResult>?> AddOrderAsync(OrderAddDto orderAddDto, string userEmail)
    {
        List<ValidationResult>? validationResults = ValidateModel.ModelValidation(orderAddDto);
        if (validationResults is null)
        {
            Trader? currentTrader = _mapper.Map<Trader>(await _traderService.GetTraderIdByEmailAsync(userEmail));
            if (currentTrader != null)
            {
                Order? order = await _orderRepository.AddOrderAsync(_mapper.Map<Order>(orderAddDto));
                if (order != null)
                {
                    order.TraderId = currentTrader.TraderId;
                    await _orderRepository.AddOrderAsync(order);
                }
            }
            return new List<ValidationResult>();
        }
        else
            return validationResults;
    }

    public async Task DeleteOrderAsync(long id)
    {
        Order? order = await _orderRepository.GetOrderByIdAsync(id);
        if (order != null)
        {
            await _orderRepository.DeleteOrderAsync(order);
            await _orderRepository.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<OrderResponseDto>?> GetAllOrdersAsync(string userEmail)
    {
        var currentTrader = await _traderService.GetTraderByEmailAsync(userEmail);
        var orders = await _orderRepository.GetAllTraderOrdersAsync(_mapper.Map<Trader>(currentTrader));
        var ordersList = new List<OrderResponseDto>();
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
                    Phone=customer.Phone1,
                    CustomerName = customer.Name,
                    ShippingType = order.shipping_type,
                    TraderId = order.TraderId,
                    SalesRepresentativeId = order.SalesRepresentativeId
                };

                orderReadDtos.Add(orderReadDto);
            }
        }
        return null;
    }

    public async Task<OrderResponseDto?> GetOrderByIdAsync(long id)
    {
        var order = await _orderRepository.GetOrderByIdAsync(id);
        if (order != null)
            return _mapper.Map<OrderResponseDto>(order);

        return null;
    }

    public async Task UpdateOrderAsync(long id, OrderUpdateDto OrderUpdateDto)
    {
        if (OrderUpdateDto != null)
        {
            var existingOrder = await _orderRepository.GetOrderByIdAsync(id);
            _mapper.Map<OrderUpdateDto>(existingOrder);
            await _orderRepository.SaveChangesAsync();
        }
    }
}

