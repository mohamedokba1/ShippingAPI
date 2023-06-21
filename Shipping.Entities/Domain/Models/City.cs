using System.ComponentModel.DataAnnotations;

namespace Shipping.Entities.Domain.Models;

public class City
{
    [Key]
    public int City_Id { get; set; }
    [Required]
    public string CityName { get; set; } = string.Empty;
    [Required]
    public double NormalShippingCost { get; set; }
    [Required]
    public double PickupShippingCost { get; set; }
    public int GovermentId { get; set; }
    public virtual Goverment? goverment { get; set; }
}
