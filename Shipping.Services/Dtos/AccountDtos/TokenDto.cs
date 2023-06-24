using System.Security.Claims;

namespace Shipping.Services.Dtos;
public class TokenDto
{
    public string Token { get; set; } = string.Empty;
    public DateTime ExpiryDate { get; set; }
    public string? Role { get; set; }
    public ICollection<Claim> Claims { get; set; } = new HashSet<Claim>();
}