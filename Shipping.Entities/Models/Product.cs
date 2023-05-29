using System.ComponentModel.DataAnnotations;

namespace Shipping.Entities.Models;

public class Product
{
    [Key]
    public Guid Product_Id { get; set; }
    [Required]
    public string ProductName { get; set; } = string.Empty;
    [Required]
    public double Weight { get; set; }
    [Required]
    public double Price { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
}
