using Microsoft.AspNetCore.Identity;
using Shipping.Entities.Domain.Models;

namespace Shipping.Entities.Domain.Identity;

public class ApplicationUserRole : IdentityRole
{
    public ICollection<RoleClaim> RoleClaims { get; set; } = new HashSet<RoleClaim>();
}
