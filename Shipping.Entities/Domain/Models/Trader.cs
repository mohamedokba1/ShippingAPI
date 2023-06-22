using Shipping.Entities.Domain.Identity;
using System.ComponentModel.DataAnnotations;

namespace Shipping.Entities.Domain.Models;

public class Trader
{
    [Key]
    public long TraderId { get; set; }

   
    [Required]
    public string UserName { get; set; } = string.Empty;
    [Required]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string PhoneNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    [Required]
    public double CostPerRefusedOrder { get; set; }
    public string? CompanyBranch { get; set; }


    public virtual ApplicationUser? User { get; set; }
    public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    public virtual ICollection<Privellge> Privellges { get; set; } = new HashSet<Privellge>();
}
