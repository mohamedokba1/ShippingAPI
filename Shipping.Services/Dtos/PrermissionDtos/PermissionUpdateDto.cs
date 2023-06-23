namespace Shipping.Services.Dtos;

public  class PermissionUpdateDto
{
    public string Name { get; set; } = string.Empty;
    public ICollection<string> Claims { get; set; } = new HashSet<string>();
}
