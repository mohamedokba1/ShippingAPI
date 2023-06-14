using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shipping.Entities.Domain.Identity;

public class ApplicationUser : IdentityUser
{
    public long TraderId { get; set; }
    public long EmployeeId { get; set; }
    public long SalesRepresentativeId { get; set; }
}
