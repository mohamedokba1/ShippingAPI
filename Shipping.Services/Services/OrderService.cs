using AutoMapper;
using Shipping.Entities.Domain.Models;
using Shipping.Repositories.Contracts;
using Shipping.Services.Dtos;
using Shipping.Services.IServices;
using Shipping.Services.Validations;
using System.ComponentModel.DataAnnotations;

namespace Shipping.Services.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly ITraderService _traderService;
    private readonly ISalesService _salesService;
    private readonly IMapper _mapper;

    public OrderService(
        IOrderRepository orderRepository,
        ICustomerRepository customerRepository,
        ITraderService traderService,
        ISalesService salesService,
        IMapper mapper)
    {
        _orderRepository = orderRepository;
        _customerRepository = customerRepository;
        _traderService = traderService;
        _salesService = salesService;
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
                    order.Trader = currentTrader;
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

    public async Task<IEnumerable<OrderReadDto>> GetAllOrdersAsync(string userEmail)
    {
        var currentTrader = await _traderService.GetTraderIdByEmailAsync(userEmail);
        var orders = await _orderRepository.GetAllTraderOrdersAsync(_mapper.Map<Trader>(currentTrader));
        var ordersList = new List<OrderReadDto>();
        foreach (var order in orders)
        {
            foreach (var customer in order.Customers)
            {
                var orderReadDto = new OrderReadDto
                {
                    OrderId = order.OrderId,
                    State = order.State,
                    PaymentMethod = order.PaymentMethod,
                    OrderDate = order.OrderDate,
                    ExtraWeightCost = order.ExtraWeightCost,
                    CompanyBranch = order.CompanyBranch,
                    DefaultCost = order.DefaultCost,
                    CustomerId = customer.Customer_Id,
                    City = customer.City,
                    Government = customer.Goverment,
                    Phone = customer.Phone1,
                    CustomerName = customer.Name,
                    ShippingType = order.shipping_type,
                    TraderId = order.TraderId,
                    SalesRepresentativeId = order.SalesRepresentativeId
                };

                ordersList.Add(orderReadDto);
            }
        }
        return ordersList;
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
