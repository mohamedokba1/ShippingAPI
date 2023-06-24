using System.ComponentModel.DataAnnotations;

namespace Shipping.Services.Dtos
{
    public class GovermentAddDto
    {
        [Required]
        public string GovermentName { get; set; } = string.Empty;
        public bool State { get; set; }
    }
}
