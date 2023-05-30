using System.ComponentModel.DataAnnotations;
using Shipping.Entities.Models;

namespace Shipping.Services.Dtos;

public class AddTraderDto
{
    public Guid Trader_Id { get; set; }
    [Required]
    [StringLength(50)]
    public string TraderName { get; set; } = string.Empty;
    [DataType(DataType.EmailAddress)]
    [StringLength(30)]
    public string? Email { get; set; }
    [Required]
    public string Address { get; set; } = string.Empty;
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
    [Required]
    public double CostPerRefusedOrder { get; set; }
    public string? CompanyBranch { get; set; }
    [DataType(DataType.PhoneNumber)]
    [Required]
    [StringLength(11)]
    public string ContactNumber { get; set; } = string.Empty;
    public ICollection<OrderResponseDto> Orders { get; set; }
    public ICollection<PrivellgeResponseDto> Privellges { get; set; }

    public Trader ToTrader()
    {
        return new Trader
        {
            TraderName = TraderName,
            Address = Address,
            Email = Email,
            Password = Password,
            CompanyBranch = CompanyBranch,
            ContactNumber = ContactNumber,
            CostPerRefusedOrder = CostPerRefusedOrder,
        };
    }
}
