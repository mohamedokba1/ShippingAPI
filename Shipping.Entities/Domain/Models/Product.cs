using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shipping.Entities.Domain.Models;

public class Product
{
    [Key]
    [Column(TypeName = "bigint")]
    public long Product_Id { get; set; }
    [Required]
    public string ProductName { get; set; } = string.Empty;
    [Required]
    public double Weight { get; set; }
    [Required]
    public double Price { get; set; }
    public int Quantity { get; set; }
    public long OrderId { get; set; }

    public virtual Order Order { get; set; }
}
