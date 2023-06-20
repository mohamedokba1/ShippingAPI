using Shipping.Entities.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Shipping.Services.Dtos;

public class ProductAddDto
{
    [Required]
    [StringLength(50,ErrorMessage ="Product Name is not valid ")]
    public string ProductName { get; set; } = string.Empty;
    [Required]
    public double Weight { get; set; }
    [Required]
    public int Quantity { get; set; }
    [Required]
    public double Price { get; set; }
    [JsonIgnore]
    public Order? Order { get; set; }
}
