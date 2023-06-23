using Microsoft.AspNetCore.Identity;
using Shipping.Entities.Domain.Models;

namespace Shipping.Entities.Domain.Identity;

public class ApplicationUserRole : IdentityRole
{
    public virtual ICollection<Permission> Permissions { get; set; } = new HashSet<Permission>();
}
