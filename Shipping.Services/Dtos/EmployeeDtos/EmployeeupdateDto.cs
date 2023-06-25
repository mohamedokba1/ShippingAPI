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
        [StringLength(50, MinimumLength = 3)]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Invalid password")]

        public string Password { get; set; } = string.Empty;
        [Required]

        [RegularExpression(@"^01[0125][0-9]{8}$", ErrorMessage = "Invalid phone number format")]
        public string? PhoneNumber { get; set; }
        [Required]
        public int branchid { get; set; }

       // [Required]
      //  public int Privellge_Id { get; init; }

        //public BranchReadDto? Branch { get; init; }
        //public PrivellageDto? Privellage { get; init; }


    }
}
