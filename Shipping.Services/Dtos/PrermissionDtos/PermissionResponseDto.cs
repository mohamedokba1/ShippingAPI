using Shipping.Services.Dtos.PrermissionDtos;
using System.Security.Claims;

namespace Shipping.Services.Dtos;

public  class PermissionResponseDto
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Date { get; set; }
    public ICollection<ClaimDto> Claims { get; set; } = new HashSet<ClaimDto>();
}
