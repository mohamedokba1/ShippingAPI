using Shipping.Entities.Domain.Identity;
using System.ComponentModel.DataAnnotations;

namespace Shipping.Services.Dtos.AccountDtos;
public class RegisterTraderDto
{
    public string Password { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    [Required(ErrorMessage = "Email can not be blank")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address")]
    public string Email { get; set; } = string.Empty;
    [Required(ErrorMessage = "User name can not be blank")]
    public string UserName { get; set; } = string.Empty;
    [Required(ErrorMessage = "Address can not be blank")]
    public string Address { get; set; } = string.Empty;
    [Required(ErrorMessage = "Cost per refused order can not be blank")]
    [Range(1, 100)]
    public double CostPerRefusedOrder { get; set; }
    public string? CompanyBranch { get; set; }
}
