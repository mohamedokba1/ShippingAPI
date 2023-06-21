using System.ComponentModel.DataAnnotations;

namespace Shipping.Services.Dtos;

public class OrderResponseDto
{
    public long OrderId { get; set; }
    public string State { get; set; } = string.Empty;
    public string PaymentMethod { get; set; } = string.Empty;
    [DataType(DataType.DateTime)]
    public string ShippingType { get; set; } = string.Empty;
    public DateTime OrderDate { get; set; }
    public double ExtraWeightCost { get; set; }
    public string CompanyBranch { get; set; } = string.Empty;
    public double TotalCost { get; set; }
    public int TotalWeight { get; set; }
    public bool IsDeleted { get; set; }
    public ICollection<ProductResponseDto>? Products { get; set; }
    public CustomerReadDto Customer { get; set; }
}