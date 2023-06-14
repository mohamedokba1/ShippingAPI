﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shipping.Entities.Domain.Models;

public class Employee
{
    [Key]
    [Column(TypeName = "bigint")]
    public long Employee_Id { get; set; }

    [Required]
    [StringLength(70)]
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
    public bool IsActive { get; set; }

    public virtual ICollection<Privellge> Privillages { get; set; } = new List<Privellge>();
    public virtual Branch branch { get; set; }
}
