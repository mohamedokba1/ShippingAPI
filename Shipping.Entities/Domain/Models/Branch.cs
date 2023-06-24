using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shipping.Entities.Domain.Models;

public class Branch
{
    [Key]
    public int Id { get; set; }
    public string BranchName { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public bool State { get; set; }
    public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    public virtual ICollection<SalesRepresentative> SalesRepresentatives { get; set; } = new HashSet<SalesRepresentative>();
}
