using System.ComponentModel.DataAnnotations;

namespace Shipping.Services.Dtos;

public class OrderUpdateDto
{
    public string State { get; set; } = string.Empty;
    public DateTime OrderDate { get; set; }
    public double TotalCost { get; set; }
    public int TotalWeight { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
    [DataType(DataType.DateTime)]
    public double ExtraWeightCost { get; set; }
    public string CompanyBranch { get; set; } = string.Empty;
    public double DefaultCost { get; set; }
    public double DeliverToVillageCost { get; set; }
    public bool DeliveredToVillage { get; set; }
    public CustomerUpdateDto Customer { get; set; }
    public string ShippingType { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }
    public ICollection<ProductUpdateDto>? Products { get; set; }
}
