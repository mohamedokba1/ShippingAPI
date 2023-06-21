namespace Shipping.Services.Dtos;
public class TokenDto
{
    public string Token { get; set; } = string.Empty;
    public DateTime ExpiryDate { get; set; }
    public string? Email { get; set; }

}