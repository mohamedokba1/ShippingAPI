using Shipping.Entities.Domain.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using Shipping.Entities.Domain;


namespace Shipping.Entities.Domain.Models;

public class Employee
{
    [Key]
    public long EmployeeId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
    [StringLength(15, MinimumLength = 3)]
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }
    public bool IsActive { get; set; }

    [ForeignKey(nameof(Branch))]
    public int BranchId { get; set; }
    [ForeignKey(nameof(User))]
    public string? UserId { get; set; }

    public virtual ApplicationUser? User { get; set; }
    public virtual Branch? Branch { get; set; }
}
