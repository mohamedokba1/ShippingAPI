using Shipping.Entities.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class BranchUpdateDto
{
    [Key]
    public int Id { get; set; }
    public string branchName { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public bool State { get; set; }
}
