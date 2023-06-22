using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shipping.Entities.Domain.Models;
public enum OrderState
{
    New, Delayed, Waiting, Rejected, Delivered
}
public enum ShippingType
{
    Normal, Express24H, Express15D
}
public enum PaymentType
{
    Cash, Visa, PackageForPackage
}
public class Order
{
    [Key]
    [Column(TypeName = "bigint")]
    public long OrderId { get; set; }
    public OrderState State { get; set; } = OrderState.New;
    public PaymentType PaymentMethod { get; set; }
    [DataType(DataType.DateTime)]
    public DateTime OrderDate { get; set; }
    public double ExtraWeightCost { get; set; }
    public string CompanyBranch { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Government { get; set; } = string.Empty;
    public ShippingType ShippingType { get; set; }
    public double TotalCost { get; set; }
    public int TotalWeight { get; set; }
    public bool DeliveredToVillage { get; set; }
    public bool IsDeleted { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    [ForeignKey(nameof(Customer))]
    public long? CustomerId { get; set; }
    public virtual Customer? Customer { get; set; }
    [ForeignKey(nameof(Trader))]
    public long? TraderId { get; set; }
    public virtual Trader? Trader { get; set; }
    [ForeignKey(nameof(SalesRepresentative))]
    public long? SalesRepresentativeId { get; set; }
    public virtual SalesRepresentative? SalesRepresentative { get; set; }
}
