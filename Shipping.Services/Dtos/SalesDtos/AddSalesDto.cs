using Shipping.Entities.Domain.Identity;
using Shipping.Entities.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Shipping.Services.Dtos;
public class AddSalesDto
{
    [Required]
    [StringLength(50,MinimumLength =5)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(50,MinimumLength =5)]
    public string UserName { get; set; } = string.Empty;


    [Required]
    [EmailAddress(ErrorMessage = "Entered Email is invalid")]
    public string Email { get; set; } = string.Empty;


    [Required]
    [DataType(DataType.Password)]
    [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Invalid password")]

    public string Password { get; set; } = string.Empty;
    [Required]
    [StringLength(11)]
    [RegularExpression(@"^01[0125][0-9]{8}$", ErrorMessage = "Invalid phone number format")]

    public string PhoneNumber { get; set; } = string.Empty;
    [Required]
    public double CompanyPercentage { get; set; }
    [Required]
    public bool IsActive { get; set; }

    public string Address { get; set; } = string.Empty;
    [Required]
    public DiscountType DiscountType { get; set; }
    public List<int>?  BranchesIds { get; set; }
    public List<int>? GovernmentsIds { get; set; }
    [JsonIgnore]
    public ApplicationUser? User { get; set; }
}
