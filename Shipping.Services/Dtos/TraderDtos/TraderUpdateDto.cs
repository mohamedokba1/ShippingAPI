using Shipping.Entities.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Shipping.Services.Dtos;

public class TraderUpdateDto
{
    [StringLength(100, ErrorMessage = "Trader name must be less than 100 characters")]
    public string UserName { get; set; } = string.Empty;
    [StringLength(200, ErrorMessage = "{0} must be less than 200 characters")]
    public string Address { get; set; } = string.Empty;
    [DataType(DataType.Password)]
    [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Invalid password")]
    public string Password { get; set; } = string.Empty;
    [Required(ErrorMessage = "Cost per refused order can not be blank")]
    public double? CostPerRefusedOrder { get; set; }
    public string? CompanyBranch { get; set; }
    [DataType(DataType.PhoneNumber)]
    [Required]
    [StringLength(11)]
    public string PhoneNumber { get; set; } = string.Empty;

    public ICollection<Privellge>? Privellges { get; set; }
}
