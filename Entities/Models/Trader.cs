using System.ComponentModel.DataAnnotations;

namespace Shipping.Entities.Models;

public class Trader
{
    [Key]
    public Guid TraderId { get; set; }
    [Required]
    public string TraderName { get; set; } = string.Empty;
}
