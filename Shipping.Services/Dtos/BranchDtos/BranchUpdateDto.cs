using Shipping.Entities.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class BranchUpdateDto
{
    public int Id { get; set; }
    [Required] 
    public string branchName { get; set; } = string.Empty;
    [Required]
    public DateTime CreatedAt { get; set; }
}
