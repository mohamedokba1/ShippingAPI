using System.ComponentModel.DataAnnotations;

namespace Shipping.Entities.Domain.Models;

public class Permission
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public bool Add { get; set; }
    public bool Update { get; set; }
    public bool Delete { get; set; }
    public bool Read { get; set; }
}
