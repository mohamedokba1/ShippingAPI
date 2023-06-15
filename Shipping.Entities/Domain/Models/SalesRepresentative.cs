using Shipping.Entities.Domain.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shipping.Entities.Domain.Models;

public class SalesRepresentative:ApplicationUser
{
    [Required]
    [StringLength(70)]
    public string Name { get; set; } = string.Empty;
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
    [Required]
    public double CompanyPercentage { get; set; }
    public string Address { get; set; } = string.Empty;

    public virtual ICollection<Goverment> Goverments { get; set; } = new HashSet<Goverment>();
    public virtual ICollection<Branch> Branchs { get; set; } = new HashSet<Branch>();
    public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    public virtual ICollection<Privellge> Privellges { get; set; } = new HashSet<Privellge>();
}
