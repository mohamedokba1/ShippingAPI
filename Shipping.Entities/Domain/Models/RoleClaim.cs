using Shipping.Entities.Domain.Identity;

namespace Shipping.Entities.Domain.Models;

public class RoleClaim
{
    public int RoleId { get; set; }
    public int ClaimId { get; set; }
    public bool Value { get; set; }
}
