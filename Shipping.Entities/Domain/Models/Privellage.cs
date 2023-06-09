using System.ComponentModel.DataAnnotations;

namespace Shipping.Entities.Domain.Models;

public class Privellge
{
    [Key]
    public Guid Privellge_Id { get; set; }
    [Required]
    public string PrivellgeName { get; set; } = string.Empty;

    public virtual ICollection<Trader> Traders { get; set; } = new HashSet<Trader>();
    public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    public virtual ICollection<SalesRepresentative> SalesRepresentatives { get; set; } = new HashSet<SalesRepresentative>();
}
