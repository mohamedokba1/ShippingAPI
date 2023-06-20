using System.ComponentModel.DataAnnotations;

namespace Shipping.Services.Dtos;
public class CustomerUpdateDto
{
    [Required]
    public string Name { get; set; }=string.Empty;
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Goverment { get; set; } = string.Empty;
    [Required]
    public string City { get; set; } = string.Empty;
    public string Village { get; set; } = string.Empty;
    [Required]
    [StringLength(11)]
    public string Phone1 { get; set; } = string.Empty;
    [StringLength(11)]
    public string Phone2 { get; set; } = string.Empty;
}
