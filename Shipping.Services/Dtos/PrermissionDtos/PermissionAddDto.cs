using System.ComponentModel.DataAnnotations;

namespace Shipping.Services.Dtos;

public class PermissionAddDto
{
    [Required(ErrorMessage = "Permission name is required")]
    [StringLength(20, ErrorMessage = "Permission name must be equal or less than 20 character")]
    public string Name { get; set; } = string.Empty;
    public DateTime date { get; set; }
}
