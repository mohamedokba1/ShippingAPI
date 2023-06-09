using System.ComponentModel.DataAnnotations;

namespace Shipping.Entities.Domain.Models;

public class Customer
{
    [Key]
    public Guid Customer_Id { get; set; }
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Goverment { get; set; } = string.Empty;
    [Required]
    public string City { get; set; } = string.Empty;
    public string? Village { get; set; }
    [Required]
    [StringLength(11)]
    public string Phone1 { get; set; } = string.Empty;
    [StringLength(11)]
    public string Phone2 { get; set; } = string.Empty;
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

}
