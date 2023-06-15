using Shipping.Entities.Domain.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shipping.Entities.Domain.Models;

public class Employee
{
    [Key]
    public long EmployeeId { get; set; }
    public bool IsActive { get; set; }

    public virtual ICollection<Privellge> Privillages { get; set; } = new List<Privellge>();
    public virtual ApplicationUser User { get; set; } = new ApplicationUser();
    public virtual Branch? branch { get; set; }
}
