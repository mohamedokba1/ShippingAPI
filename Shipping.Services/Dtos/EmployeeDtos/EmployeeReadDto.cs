using Shipping.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Services.Dtos
{
    public record EmployeeReadDto 
    {
        
        public Guid Employee_Id { get; init; }

        [Required]
        [StringLength(70)]
        public  string Name { get; init; } = string.Empty;
        public  string Email { get; init; } = string.Empty;
        public  string UserName { get; init; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public  string Password { get; init; } = string.Empty;
        public  bool IsActive { get; init; }

      //  public  virtual ICollection<Privellge> Privillages { get; init; } = new List<Privellge>();
    }
}
