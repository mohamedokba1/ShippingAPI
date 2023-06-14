using Shipping.Entities.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Shipping.Services.Dtos;
public class CustomerReadDto
{
    public long CustomerId { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Goverment { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Village { get; set; } = string.Empty;
    public string Phone1 { get; set; } = string.Empty;
    public string Phone2 { get; set; } = string.Empty;
    public ICollection<OrderReadDto>? Orders { get; set; }
}

public class OrderReadDto
{
    
    public Guid OrderId { get; set; }
    public OrderState State { get; set; }
    public PaymentType PaymentMethod { get; set; }
    [DataType(DataType.DateTime)]
    public DateTime OrderDate { get; set; }
    public double ExtraWeightCost { get; set; }
    public string CompanyBranch { get; set; }=string.Empty;
    public double DefaultCost { get; set; }
    public Guid CustomerId { get; set; }
    public string City { get; set; } = string.Empty;
    public string Government { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
    public ShippingType ShippingType { get; set; }
    public Guid TraderId { get; set; }
    public Guid SalesRepresentativeId { get; set; }
    public ICollection<CustomerReadDto>? Customers { get; set; }

}