using System.ComponentModel.DataAnnotations;

namespace Shipping.Services.Dtos
{
    public record EmployeeReadDto
    {
        public long EmployeeId { get; init; }

        [Required]
        [StringLength(70)]
        public  string Name { get; init; } = string.Empty;
        public  string Email { get; init; } = string.Empty;
        public  string UserName { get; init; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public  string Password { get; init; } = string.Empty;
        public  bool IsActive { get; init; }

        [Phone]
        public string? PhoneNumber { get; init; } 

        public BranchReadDto? Branch { get; init ; }

       
    }
}
