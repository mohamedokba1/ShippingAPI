using System.ComponentModel.DataAnnotations;

namespace Shipping.Services.Dtos
{
    public class GovermentReadDto
    {
        public int Goverment_Id { get; set; }
        [Required]
        public string GovermentName { get; set; } = string.Empty;
        public bool State { get; set; }
        public ICollection<CityReadDto> Cities { get; set; } = new HashSet<CityReadDto>();
    }
}
