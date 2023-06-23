namespace Shipping.Services.Dtos;

public  class PermissionUpdateDto
{
    public int Privellge_Id { get; set; }
    public string PrivellgeName { get; set; } = string.Empty;
    public DateTime date { get; set; }
}
