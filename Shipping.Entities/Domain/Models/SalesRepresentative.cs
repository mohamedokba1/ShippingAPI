using Shipping.Entities.Domain.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shipping.Entities.Domain.Models;

public enum DiscountType
{
    Percentage ,
    FixedValue

}

public class SalesRepresentative
{
    [Key]
    public long SalesRepresentativeId { get; set; }
    [Required]
    public string Email { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public double CompanyPercentage { get; set; }
    public string Address { get; set; } = string.Empty;
    public  bool IsActive { get; set; }
    public DiscountType DiscountType { get; set; }
    [ForeignKey(nameof(User))]
    public string? UserId { get; set; }
    public virtual ApplicationUser? User { get; set; }
    public virtual ICollection<Goverment> Goverments { get; set; } = new HashSet<Goverment>();
    public virtual ICollection<Branch> Branches { get; set; } = new HashSet<Branch>();
    public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
}
