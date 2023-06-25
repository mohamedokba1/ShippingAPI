using Microsoft.AspNetCore.Identity;

namespace Shipping.Entities.Domain.Identity;

public class ApplicationUserRole : IdentityRole
{
    public DateTime Date { get; set; } = DateTime.Now;
}
