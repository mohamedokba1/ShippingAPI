using System.ComponentModel.DataAnnotations;

namespace Shipping.Services.Dtos;
public class CityUpdateDto
{
    public int CityId { get; set; }

    [Required(ErrorMessage = "City name is required")]
    public string CityName { get; set; }=string.Empty;

    [Required(ErrorMessage = "Normal shipping cost is required")]
    [Range(0, double.MaxValue, ErrorMessage = "Normal shipping cost must be a positive value")]
    public double NormalShippingCost { get; set; }
    public double PickupShippingCost { get; set; }
    public int GovermentId { get; set; }

}