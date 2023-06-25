namespace Shipping.Services.Dtos;

public  class PermissionUpdateDto
{
    public string Name { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public ICollection<string> Claims { get; set; } = new HashSet<string>();
}
