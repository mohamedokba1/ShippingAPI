using Shipping.Entities.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Shipping.Services.Dtos;

public class OrderUpdateDto
{
    public OrderState State { get; set; } = OrderState.New;
    public PaymentType PaymentMethod { get; set; }
    [DataType(DataType.DateTime)]
    public double ExtraWeightCost { get; set; }
    public string CompanyBranch { get; set; } = string.Empty;
    public double DefaultCost { get; set; }
    public CustomerUpdateDto Customer { get; set; }
    public ShippingType ShippingType { get; set; }
    public bool IsDeleted { get; set; }
    public ICollection<ProductResponseDto>? Products { get; set; }
}
