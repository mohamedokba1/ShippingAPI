using System.ComponentModel.DataAnnotations;

namespace Shipping.Entities.Models;
public enum OrderState
{
    New, Waiting, Delayed, Rejected, Delivered
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
    public Guid Order_Id { get; set; }
    public OrderState State { get; set; } = OrderState.New;
    public PaymentType PaymentMethod { get; set; }
    [DataType(DataType.DateTime)]
    public DateTime OrderDate { get; set; }
    public double ExtraWeightCost { get; set; }
    public string CompanyBranch { get; set; } = string.Empty;
    public double DefaultCost { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public ShippingType shipping_type { get; set; }


    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
    public virtual Trader traderId { get; set; }
    public virtual SalesRepresentative salesRepresentativeId { get; set; }
}
