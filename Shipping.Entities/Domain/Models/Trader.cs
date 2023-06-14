using Shipping.Entities.Domain.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shipping.Entities.Domain.Models;

public class Trader:ApplicationUser
{
    [Key]
    [Column(TypeName="bigint")]
    public long TraderId { get; set; }
    [Required]
    [StringLength(50)]
    public string TraderName { get; set; } = string.Empty;
    [DataType(DataType.EmailAddress)]
    [StringLength(30)]
    public string? Email { get; set; }
    [Required]
    public string Address { get; set; } = string.Empty;
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
    [Required]
    public double CostPerRefusedOrder { get; set; }
    public string? CompanyBranch { get; set; }
    [DataType(DataType.PhoneNumber)]
    [Required]
    [StringLength(11)]
    public string ContactNumber { get; set; } = string.Empty;

    public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    public virtual ICollection<Privellge> Privellges { get; set; } = new HashSet<Privellge>();
}
