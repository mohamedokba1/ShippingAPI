namespace Shipping.Services.Dtos;

public  class PermissionResponseDto
{
    public string Name { get; set; } = string.Empty;
    public bool Add { get; set; }
    public bool Update { get; set; }
    public bool Delete { get; set; }
    public bool Read { get; set; }
}
