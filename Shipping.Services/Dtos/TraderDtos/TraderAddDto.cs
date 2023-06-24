using Shipping.Entities.Domain.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Shipping.Services.Dtos;

public class TraderAddDto
{
    [Required(ErrorMessage = "{0} can not be blank")]
    [StringLength(50)]
    public string UserName { get; set; } = string.Empty;
    [Required(ErrorMessage = "{0} can not be blank")]
    [EmailAddress(ErrorMessage = "The Entered email is not valid")]
    [StringLength(30)]
    public string? Email { get; set; }
    [Required(ErrorMessage= "{0} can not be blank")]
    public string Address { get; set; } = string.Empty;
    [Required(ErrorMessage = "{0} can not be blank")]
    [DataType(DataType.Password)]
    [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Invalid password")]
    public string Password { get; set; } = string.Empty;
    [Required(ErrorMessage = "Cost per refused order can not be blank")]
    public double CostPerRefusedOrder { get; set; }
    public string? CompanyBranch { get; set; }
    [Phone(ErrorMessage = "Invalid phone number")]
    [Required(ErrorMessage = "{0} can not be blank")]
    [StringLength(11)]
    public string PhoneNumber { get; set; } = string.Empty;
    [JsonIgnore]
    public ApplicationUser? User { get; set; }
}
