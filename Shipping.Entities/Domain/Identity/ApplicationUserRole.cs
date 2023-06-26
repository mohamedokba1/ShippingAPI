using Microsoft.AspNetCore.Identity;

namespace Shipping.Entities.Domain.Identity;

public class ApplicationUserRole : IdentityRole
{
    public string? Date { get; set; } 
}
