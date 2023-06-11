using System.ComponentModel.DataAnnotations;

namespace Shipping.Services.Dtos;

public class TraderUpdateDto
{

    [Required(ErrorMessage = "{0} can not be blank")]
    [StringLength(50)]
    public string TraderName { get; set; } = string.Empty;
    [Required(ErrorMessage = "{0} can not be blank")]
    [EmailAddress(ErrorMessage = "The entered {0} is not valid email")]
    [StringLength(30)]
    public string? Email { get; set; }
    [Required(ErrorMessage = "{0} can not be blank")]
    public string Address { get; set; } = string.Empty;
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
    [Required(ErrorMessage = "Cost per refused order can not be blank")]
    public double? CostPerRefusedOrder { get; set; }
    public string? CompanyBranch { get; set; }
    [DataType(DataType.PhoneNumber)]
    [Required]
    [StringLength(11)]
    public string ContactNumber { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }
}
