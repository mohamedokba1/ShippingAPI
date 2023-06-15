using Microsoft.AspNetCore.Identity;
using Shipping.Entities.Domain.Models;

namespace Shipping.Entities.Domain.Identity;

public class ApplicationUser : IdentityUser
{
    public ICollection<Trader> TraderId { get; set; } = new HashSet<Trader>();
    public ICollection<Employee> EmployeeId { get; set; } = new HashSet<Employee>();
    public ICollection<SalesRepresentative> SalesRepresentativeId { get; set; } = new HashSet<SalesRepresentative>();
}
