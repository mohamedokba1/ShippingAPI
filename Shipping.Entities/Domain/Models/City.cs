using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shipping.Entities.Domain.Models;

public class City
{
    [Key]
    public int City_Id { get; set; }
    [Required]
    public string CityName { get; set; } = string.Empty;
    [Required]
    public double NormalShippingCost { get; set; }
    public int GovermentId { get; set; }
    public virtual Goverment? goverment { get; set; }
}
