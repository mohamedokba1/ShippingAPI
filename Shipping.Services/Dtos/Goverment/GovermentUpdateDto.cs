using System.ComponentModel.DataAnnotations;

namespace Shipping.Services.Dtos
{
    public class GovermentUpdateDto
    {
        [Required]
        public string GovermentName { get; set; } = string.Empty;
        public bool State { get; set; }
        // public ICollection<City> Cities { get; set; } = new HashSet<City>();
    }
}
