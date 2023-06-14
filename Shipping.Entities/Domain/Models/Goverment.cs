using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shipping.Entities.Domain.Models;

public class Goverment
{
    [Key]
    public int Goverment_Id { get; set; }
    [Required]
    public string GovermentName { get; set; } = string.Empty;
    public bool State { get; set; }
    public ICollection<City> Cities { get; set; } = new HashSet<City>();
    public ICollection<SalesRepresentative> SalesRepresentatives { get; set; } = new HashSet<SalesRepresentative>();
}
