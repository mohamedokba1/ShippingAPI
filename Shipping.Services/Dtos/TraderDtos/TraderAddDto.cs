using System.ComponentModel.DataAnnotations;
using Shipping.Entities.Domain.Models;

namespace Shipping.Services.Dtos;

public class TraderAddDto
{
    [Required]
    [StringLength(50)]
    public string TraderName { get; set; } = string.Empty;
    [Required(ErrorMessage = "Email can not be blank")]
    [EmailAddress(ErrorMessage = "The Entered email is not valid")]
    [StringLength(30)]
    public string? Email { get; set; }
    [Required(ErrorMessage= "Address can not be blank")]
    public string Address { get; set; } = string.Empty;
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
    [Required(ErrorMessage = "Cost per refused order can not be blank")]
    public double CostPerRefusedOrder { get; set; }
    public string? CompanyBranch { get; set; }
    [DataType(DataType.PhoneNumber)]
    [Required]
    [StringLength(11)]
    public string ContactNumber { get; set; } = string.Empty;
}
