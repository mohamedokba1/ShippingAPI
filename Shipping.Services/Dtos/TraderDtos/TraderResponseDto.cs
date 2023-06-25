namespace Shipping.Services.Dtos;

public class TraderResponseDto
{
    public long TraderId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string Address { get; set; } = string.Empty;
    public double CostPerRefusedOrder { get; set; }
    public string? CompanyBranch { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public ICollection<OrderResponseDto> Orders { get; set; }
}
