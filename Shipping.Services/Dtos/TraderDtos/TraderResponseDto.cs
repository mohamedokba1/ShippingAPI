using Shipping.Entities.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Shipping.Services.Dtos;

public class TraderResponseDto
{
    public Guid Trader_Id { get; set; }
    public string TraderName { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string Address { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public double CostPerRefusedOrder { get; set; }
    public string? CompanyBranch { get; set; }
    public string ContactNumber { get; set; } = string.Empty;
    public ICollection<OrderResponseDto> Orders { get; set; }
    public ICollection<Privellge> Privellges { get; set; }
}
