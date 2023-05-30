using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CityUpdateDto
{
    public int CityId { get; set; }

    [Required(ErrorMessage = "City name is required")]
    public string CityName { get; set; }

    [Required(ErrorMessage = "Normal shipping cost is required")]
    [Range(0, double.MaxValue, ErrorMessage = "Normal shipping cost must be a positive value")]
    public double NormalShippingCost { get; set; }
}