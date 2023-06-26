using System.ComponentModel.DataAnnotations;

namespace Shipping.Services.Dtos;

public class ProductUpdateDto
{
    [Required]
    [StringLength(50, ErrorMessage = "Product Name is not valid ")]
    public string ProductName { get; set; } = string.Empty;
    [Required]
    public double Weight { get; set; }
    [Required]
    public double Price { get; set; }
    public double Quantity { get; set; }
}
