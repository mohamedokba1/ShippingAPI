using System.ComponentModel.DataAnnotations;

namespace Shipping.Entities.Domain.Models;

public class SpecialPackage
{
    [Key]
    public int Id { get; set; }
    public double ShippingCost { get; set; }
    public Goverment? goverment { get; set; }
    public City? city { get; set; }
    public virtual Trader? trader { get; set; }
}
