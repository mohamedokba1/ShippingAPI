using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shipping.Entities.Domain.Models;

public class Privellge
{
    [Key]
    [Column(TypeName = "int")]
    public int Privellge_Id { get; set; }
    [Required]
    public string PrivellgeName { get; set; } = string.Empty;

    public virtual ICollection<Trader> Traders { get; set; } = new HashSet<Trader>();
    public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    public virtual ICollection<SalesRepresentative> SalesRepresentatives { get; set; } = new HashSet<SalesRepresentative>();
}
