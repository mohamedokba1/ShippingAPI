using System.ComponentModel.DataAnnotations;

namespace Shipping.Entities.Models;

public class Trader
{
    [Key]
    public Guid TraderId { get; set; }
    [Required]
    [StringLength(50)]
    public string TraderName { get; set; } = string.Empty;
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }
    [Required]
    public string Address { get; set; } = string.Empty;
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
    public double CostPerRefusedOrder { get; set; }
    public string? CompanyBranch { get; set; }
    [DataType(DataType.PhoneNumber)]
    public string ContactNumber { get; set; } = string.Empty;
}
