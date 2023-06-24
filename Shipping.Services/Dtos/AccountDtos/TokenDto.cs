using Shipping.Services.Dtos.PrermissionDtos;
using System.Security.Claims;

namespace Shipping.Services.Dtos;
public class TokenDto
{
    public string Token { get; set; } = string.Empty;
    public DateTime ExpiryDate { get; set; }
    public string? Role { get; set; }
    public ICollection<ClaimDto> Claims { get; set; } = new HashSet<ClaimDto>();
}