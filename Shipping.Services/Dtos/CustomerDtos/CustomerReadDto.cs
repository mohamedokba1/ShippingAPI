namespace Shipping.Services.Dtos;
public class CustomerReadDto
{
    public long CustomerId { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Goverment { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Village { get; set; } = string.Empty;
    public string Phone1 { get; set; } = string.Empty;
    public string Phone2 { get; set; } = string.Empty;
}
