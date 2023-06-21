using Microsoft.AspNetCore.Identity;
using Shipping.Entities.Domain.Models;

namespace Shipping.Entities.Domain.Identity;

public class ApplicationUserRole : IdentityRole
{
    public ICollection<Privellge> Privellges { get; set; }
}
