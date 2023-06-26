using Shipping.Entities.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Shipping.Services.Dtos;

public class OrderAddDto
{
    [Required(ErrorMessage = "Payment method is required")]
    public PaymentType PaymentMethod { get; set; }
    [DataType(DataType.DateTime)]
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public ShippingType ShippingType { get; set; }
    public WeightOptions WeightOption { get; set; }
    [JsonIgnore]
    public double? ExtraWeightCost { get; set; }
    public string CompanyBranch { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public double? TotalCost { get; set; }
    public double? TotalWeight { get; set; }
    public double DeliverToVillageCost { get; set; }
    public bool DeliveredToVillage { get; set; }
    public CustomerAddDto Customer { get; set; }
    public ICollection<ProductAddDto> Products { get; set; } = new HashSet<ProductAddDto>();
}

public record WeightOptions(int allowedWeight = 1, double costPerKG = 1);
