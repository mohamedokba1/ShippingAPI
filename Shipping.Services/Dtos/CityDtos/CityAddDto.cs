using Shipping.Entities.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Shipping.Services.Dtos;
public class CityAddDto
{
    public int CityId { get; set; }

    [Required(ErrorMessage = "City name is required")]
    public string CityName { get; set; }=string.Empty;

    [Required(ErrorMessage = "Normal shipping cost is required")]
    [Range(0, double.MaxValue, ErrorMessage = "Normal shipping cost must be a positive value")]
    public double NormalShippingCost { get; set; }

    [Required(ErrorMessage = "Pickup shipping cost is required")]
    [Range(0, double.MaxValue, ErrorMessage = "Pickup shipping cost must be a positive value")]
    public double PickupShippingCost { get; set; }
    public int GovernmentId { get; set; }

}
