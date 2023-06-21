using Shipping.Entities.Domain.Models;
using Shipping.Services.Dtos;
using Shipping.Services.Dtos.SalesDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class BranchReadDto
{
    [Key]
    public int Id { get; set; }
    public string branchName { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public bool State { get; set; }
   
}
