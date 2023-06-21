using Shipping.Entities.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Services.Dtos;

public class SalesUpdateDtos
{
    [Key]
    public long SalesRepresentative_Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 5)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(50, MinimumLength = 5)]
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


    public string Address { get; set; } = string.Empty;
    [Required]
    public DiscountType DiscountType { get; set; }
    public List<int>? BranchesIds { get; set; }
    public List<int>? GovernmentsIds { get; set; }



}
