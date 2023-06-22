using Shipping.Entities.Domain.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shipping.Entities.Domain.Models;

public class Privellge
{
    [Key]
    [Column(TypeName = "int")]
    public int Privellge_Id { get; set; }
    [Required]
    public string PrivellgeName { get; set; } = string.Empty;
    public DateTime date { get; set; }
    public ICollection<ApplicationUserRole> Roles { get; set; }
        
     

}
