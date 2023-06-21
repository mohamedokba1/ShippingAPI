using Shipping.Entities.Domain.Models;

namespace Shipping.Services.Dtos;

public class ProductResponseDto
{
    public string ProductName { get; set; } = string.Empty;
    public double Weight { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
}