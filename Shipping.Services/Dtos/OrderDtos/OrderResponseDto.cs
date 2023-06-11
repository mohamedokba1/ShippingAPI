using Shipping.Entities.Domain.Models;
using System.ComponentModel.DataAnnotations;


namespace Shipping.Services.Dtos;

public class OrderResponseDto
{
    public Guid Id { get; set; }
    public OrderState State { get; set; } = OrderState.New;
    public PaymentType PaymentMethod { get; set; }
    [DataType(DataType.DateTime)]
    public DateTime OrderDate { get; set; }
    public double ExtraWeightCost { get; set; }
    public string CompanyBranch { get; set; } = string.Empty;
    public double DefaultCost { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public ShippingType shipping_type { get; set; }
    public bool IsDeleted { get; set; }
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
