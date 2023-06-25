using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Shipping.Entities.Domain.Identity;
using Shipping.Entities.Domain.Models;
using Shipping.Repositories;
using Shipping.Repositories.Contracts;
using Shipping.Services.Dtos;
using Shipping.Services.IServices;
using Shipping.Services.Validations;
using System.ComponentModel.DataAnnotations;

namespace Shipping.Services.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly ITraderService _traderService;
    private readonly IMapper _mapper;
    private readonly ICityService _cityService;
    private readonly ISalesService _salesService;
    private readonly ICustomerService _customerService;
    private readonly UserManager<ApplicationUser> _userManager;
    public OrderService(
        IOrderRepository orderRepository,
        ITraderService traderService,
        IMapper mapper, ICityService cityService, ISalesService salesService, ICustomerService customerService, UserManager<ApplicationUser> userManager)
    {
        _orderRepository = orderRepository;
        _traderService = traderService;
        _mapper = mapper;
        _cityService=cityService;
        _salesService=salesService;
        _customerService=customerService;
        _userManager=userManager;

    }

    public async Task<List<ValidationResult>?> AddOrderAsync(OrderAddDto orderAddDto, string userEmail)
    {
        List<ValidationResult>? validationResults = ValidateModel.ModelValidation(orderAddDto);
        if (validationResults?.Count == 0)
        {
            long? currentTraderId = await _traderService.GetTraderIdByEmailAsync(userEmail);
            if (currentTraderId != null)
            {
                var city = await _cityService.GetByNameAsync(orderAddDto.City);
                switch (orderAddDto.PaymentMethod)
                {
                    case PaymentType.Cash:
                        switch (orderAddDto.ShippingType)
                        {
                            case ShippingType.Normal:
                                foreach (ProductAddDto product in orderAddDto.Products)
                                {
                                    orderAddDto.TotalCost += (product.Price * product.Quantity);
                                    orderAddDto.TotalWeight += (product.Weight * product.Quantity);
                                }
                                if (orderAddDto.TotalWeight > orderAddDto.WeightOption.allowedWeight)
                                {
                                    double overWeight = (double)orderAddDto.TotalWeight - orderAddDto.WeightOption.allowedWeight;
                                    orderAddDto.TotalCost += (overWeight * orderAddDto.WeightOption.costPerKG);
                                    orderAddDto.ExtraWeightCost = overWeight * orderAddDto.WeightOption.costPerKG;
                                }
                                if (orderAddDto.DeliveredToVillage)
                                    orderAddDto.TotalCost += orderAddDto.DeliverToVillageCost;
                                if (city != null)
                                    orderAddDto.TotalCost += city.NormalShippingCost;
                                break;

                            case ShippingType.Express24H:
                                foreach (ProductAddDto product in orderAddDto.Products)
                                {
                                    orderAddDto.TotalCost += (product.Price * product.Quantity);
                                    orderAddDto.TotalWeight += (product.Weight * product.Quantity);
                                }
                                if (orderAddDto.TotalWeight > orderAddDto.WeightOption.allowedWeight)
                                {
                                    double overWeight = (double)orderAddDto.TotalWeight - orderAddDto.WeightOption.allowedWeight;
                                    orderAddDto.TotalCost += (overWeight * orderAddDto.WeightOption.costPerKG);
                                    orderAddDto.ExtraWeightCost = overWeight * orderAddDto.WeightOption.costPerKG;
                                }
                                if (orderAddDto.DeliveredToVillage)
                                    orderAddDto.TotalCost += orderAddDto.DeliverToVillageCost;
                                if (city != null)
                                    orderAddDto.TotalCost += city.NormalShippingCost * 2;
                                break;

                            case ShippingType.Express15D:
                                foreach (ProductAddDto product in orderAddDto.Products)
                                {
                                    orderAddDto.TotalCost += (product.Price * product.Quantity);
                                    orderAddDto.TotalWeight += (product.Weight * product.Quantity);
                                }
                                if (orderAddDto.TotalWeight > orderAddDto.WeightOption.allowedWeight)
                                {
                                    double overWeight = (double)orderAddDto.TotalWeight - orderAddDto.WeightOption.allowedWeight;
                                    orderAddDto.TotalCost += (overWeight * orderAddDto.WeightOption.costPerKG);
                                    orderAddDto.ExtraWeightCost = overWeight * orderAddDto.WeightOption.costPerKG;
                                }
                                if (orderAddDto.DeliveredToVillage)
                                    orderAddDto.TotalCost += orderAddDto.DeliverToVillageCost;
                                if (city != null)
                                    orderAddDto.TotalCost += city.NormalShippingCost / 2;
                                break;
                        }
                        break;

                    case PaymentType.Visa:
                        switch (orderAddDto.ShippingType)
                        {
                            case ShippingType.Normal:
                                foreach (var product in orderAddDto.Products)
                                {
                                    orderAddDto.TotalWeight += (product.Weight * product.Quantity);
                                }
                                if (orderAddDto.TotalWeight > orderAddDto.WeightOption.allowedWeight)
                                {
                                    double overWeight = (double)orderAddDto.TotalWeight - orderAddDto.WeightOption.allowedWeight;
                                    orderAddDto.TotalCost += (overWeight * orderAddDto.WeightOption.costPerKG);
                                    orderAddDto.ExtraWeightCost = overWeight * orderAddDto.WeightOption.costPerKG;
                                }
                                if (orderAddDto.DeliveredToVillage)
                                    orderAddDto.TotalCost += orderAddDto.DeliverToVillageCost;

                                if (city != null)
                                    orderAddDto.TotalCost += city.NormalShippingCost;
                                break;

                            case ShippingType.Express24H:
                                foreach (var product in orderAddDto.Products)
                                {
                                    orderAddDto.TotalWeight += (product.Weight * product.Quantity);
                                }
                                if (orderAddDto.TotalWeight > orderAddDto.WeightOption.allowedWeight)
                                {
                                    double overWeight = (double)orderAddDto.TotalWeight - orderAddDto.WeightOption.allowedWeight;
                                    orderAddDto.TotalCost += (overWeight * orderAddDto.WeightOption.costPerKG);
                                    orderAddDto.ExtraWeightCost = overWeight * orderAddDto.WeightOption.costPerKG;
                                }
                                if (orderAddDto.DeliveredToVillage)
                                    orderAddDto.TotalCost += orderAddDto.DeliverToVillageCost;

                                if (city != null)
                                    orderAddDto.TotalCost += city.NormalShippingCost * 2;
                                break;

                            case ShippingType.Express15D:
                                foreach (var product in orderAddDto.Products)
                                {
                                    orderAddDto.TotalWeight += (product.Weight * product.Quantity);
                                }
                                if (orderAddDto.TotalWeight > orderAddDto.WeightOption.allowedWeight)
                                {
                                    double overWeight = (double)orderAddDto.TotalWeight - orderAddDto.WeightOption.allowedWeight;
                                    orderAddDto.TotalCost += (overWeight * orderAddDto.WeightOption.costPerKG);
                                    orderAddDto.ExtraWeightCost = overWeight * orderAddDto.WeightOption.costPerKG;
                                }
                                if (orderAddDto.DeliveredToVillage)
                                    orderAddDto.TotalCost += orderAddDto.DeliverToVillageCost;
                                if (city != null)
                                    orderAddDto.TotalCost += city.NormalShippingCost / 2;
                                break;
                        }
                        break;

                    case PaymentType.PackageForPackage:
                        switch (orderAddDto.ShippingType)
                        {
                            case ShippingType.Normal:
                                foreach (var product in orderAddDto.Products)
                                {
                                    orderAddDto.TotalWeight += (product.Weight * product.Quantity);
                                }
                                if (orderAddDto.TotalWeight > orderAddDto.WeightOption.allowedWeight)
                                {
                                    double overWeight = (double)orderAddDto.TotalWeight - orderAddDto.WeightOption.allowedWeight;
                                    orderAddDto.TotalCost += (overWeight * orderAddDto.WeightOption.costPerKG);
                                    orderAddDto.ExtraWeightCost = overWeight * orderAddDto.WeightOption.costPerKG;
                                }
                                if (orderAddDto.DeliveredToVillage)
                                {
                                    orderAddDto.TotalCost += orderAddDto.DeliverToVillageCost;
                                }
                                if (city != null)
                                    orderAddDto.TotalCost += city.NormalShippingCost;
                                break;

                            case ShippingType.Express24H:
                                foreach (var product in orderAddDto.Products)
                                {
                                    orderAddDto.TotalWeight += (product.Weight * product.Quantity);
                                }
                                if (orderAddDto.TotalWeight > orderAddDto.WeightOption.allowedWeight)
                                {
                                    double overWeight = (double)orderAddDto.TotalWeight - orderAddDto.WeightOption.allowedWeight;
                                    orderAddDto.TotalCost += (overWeight * orderAddDto.WeightOption.costPerKG);
                                    orderAddDto.ExtraWeightCost = overWeight * orderAddDto.WeightOption.costPerKG;
                                }
                                if (orderAddDto.DeliveredToVillage)
                                {
                                    orderAddDto.TotalCost += orderAddDto.DeliverToVillageCost;
                                }
                                if (city != null)
                                    orderAddDto.TotalCost += city.NormalShippingCost * 2;
                                break;

                            case ShippingType.Express15D:
                                foreach (var product in orderAddDto.Products)
                                {
                                    orderAddDto.TotalWeight += (product.Weight * product.Quantity);
                                }
                                if (orderAddDto.TotalWeight > orderAddDto.WeightOption.allowedWeight)
                                {
                                    double overWeight = (double)orderAddDto.TotalWeight - orderAddDto.WeightOption.allowedWeight;
                                    orderAddDto.TotalCost += (overWeight * orderAddDto.WeightOption.costPerKG);
                                    orderAddDto.ExtraWeightCost = overWeight * orderAddDto.WeightOption.costPerKG;
                                }
                                if (orderAddDto.DeliveredToVillage)
                                    orderAddDto.TotalCost += orderAddDto.DeliverToVillageCost;
                                if (city != null)
                                    orderAddDto.TotalCost += city.NormalShippingCost / 2;
                                break;
                        }
                        break;
                }
                Order? order = _mapper.Map<Order>(orderAddDto);
                if (order != null)
                {
                    order.TraderId = (long)currentTraderId;
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
        IEnumerable<OrderResponseDto>? ordersResponse = new List<OrderResponseDto>();
        ApplicationUser? user = await _userManager.FindByEmailAsync(userEmail);
        if (user != null)
        {
            if (await _userManager.IsInRoleAsync(user, "trader"))
            {
                var traderId = await _traderService.GetTraderIdByEmailAsync(userEmail);
                if (traderId != null)
                {
                    ordersResponse = _mapper.Map<IEnumerable<OrderResponseDto>>
                    (await _orderRepository.GetAllTraderOrdersAsync((long)traderId));
                }
            }
            else if (await _userManager.IsInRoleAsync(user, "salesrepsentative"))
            {
                var salesId = await _salesService.GetSalesRepresentativeIdByEmail(userEmail);
                if (salesId != null)
                {
                    ordersResponse = _mapper.Map<IEnumerable<OrderResponseDto>>
                    (await _orderRepository.GetAllSalesOrdersAsync((long)salesId));
                }
            }
            else
            {
                ordersResponse = _mapper.Map<IEnumerable<OrderResponseDto>>
                (await _orderRepository.GetAllOrdersAsync());
            }

            return ordersResponse;
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

    public IQueryable<OrderResponseDto> GetOrderesPaginated()
    {
        IQueryable orderes = _orderRepository.GetOrderPaginated();
        return orderes.ProjectTo<OrderResponseDto>(_mapper.ConfigurationProvider);
    }

    public async Task<List<ValidationResult>?> UpdateOrderAsync(long id, OrderUpdateDto orderUpdateDto)
    {
        List<ValidationResult>? errors = ValidateModel.ModelValidation(orderUpdateDto);
        if (errors?.Count == 0)
        {
            Order? existingOrder = await _orderRepository.GetOrderByIdAsync(id);
            if(existingOrder != null)
            {
                _mapper.Map<OrderUpdateDto, Order>(orderUpdateDto, existingOrder);
                await _orderRepository.SaveChangesAsync();
            }
            return new List<ValidationResult>();
        }
        return errors;
    }
}