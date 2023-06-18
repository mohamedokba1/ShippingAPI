using System.ComponentModel.DataAnnotations;

namespace Shipping.Services.Dtos
{
    public class EmployeeupdateDto
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;
        [EmailAddress]

        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        [StringLength(15, MinimumLength = 6)]
        public string Password { get; set; } = string.Empty;
        [Required]

        [RegularExpression(@"^01[0125][0-9]{8}$", ErrorMessage = "Invalid phone number format")]
        public string? PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public int branchid { get; set; }

        [Required]
        public int Privellge_Id { get; init; }


    }
}
