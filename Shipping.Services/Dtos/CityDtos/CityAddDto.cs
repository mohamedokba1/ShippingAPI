using System.ComponentModel.DataAnnotations;

namespace Shipping.Services.Dtos;
public class CityAddDto
{
    [Required(ErrorMessage = "City name is required")]
    public string CityName { get; set; }

    [Required(ErrorMessage = "Normal shipping cost is required")]
    [Range(0, double.MaxValue, ErrorMessage = "Normal shipping cost must be a positive value")]
    public double NormalShippingCost { get; set; }
}
