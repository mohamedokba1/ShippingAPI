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
    public long Order_Id { get; set; }
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

    public long ProductId { get; set; }
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
    public virtual Trader? Trader { get; set; }
    public virtual SalesRepresentative? SalesRepresentative { get; set; }
}
