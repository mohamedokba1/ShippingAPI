using Shipping.Entities.Domain.Models;
using System.ComponentModel.DataAnnotations;


namespace Shipping.Services.Dtos;

public class OrderResponseDto
{
    public long Id { get; set; }
    public OrderState State { get; set; } = OrderState.New;
    public PaymentType PaymentMethod { get; set; }
    [DataType(DataType.DateTime)]
    public DateTime OrderDate { get; set; }
    public double ExtraWeightCost { get; set; }
    public string CompanyBranch { get; set; } = string.Empty;
    public double DefaultCost { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public ShippingType shipping_type { get; set; }
    public ICollection<Product>? Products { get; set; }
}
public class OrderReadDto
{

    public long OrderId { get; set; }
    public OrderState State { get; set; }
    public PaymentType PaymentMethod { get; set; }
    [DataType(DataType.DateTime)]
    public DateTime OrderDate { get; set; }
    public double ExtraWeightCost { get; set; }
    public string CompanyBranch { get; set; } = string.Empty;
    public double DefaultCost { get; set; }
    public long CustomerId { get; set; }
    public string City { get; set; } = string.Empty;
    public string Government { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public ShippingType ShippingType { get; set; }
    public long TraderId { get; set; }
    public long SalesRepresentativeId { get; set; }
    public ICollection<CustomerReadDto>? Customers { get; set; }

}