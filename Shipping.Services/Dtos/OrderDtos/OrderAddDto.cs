using Shipping.Entities.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Shipping.Services.Dtos;

public class OrderAddDto
{
    [Required(ErrorMessage = "Payment method is required")]
    public PaymentType PaymentMethod { get; set; }
    [DataType(DataType.DateTime)]
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public double ExtraWeightCost { get; set; }
    public string CompanyBranch { get; set; } = string.Empty;
    public double DefaultCost { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public double TotalCost { get; set; }
    public int TotalWeight { get; set; }
    public bool DeliveredToVillage { get; set; }
    public ShippingType shipping_type { get; set; }
    public ICollection<Product> Products { get; set; } = new HashSet<Product>();
}
