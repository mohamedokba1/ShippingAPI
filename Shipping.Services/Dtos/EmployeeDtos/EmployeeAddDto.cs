using Shipping.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Services.Dtos
{
    public class EmployeeAddDto
    {
        

        [Required]
        [StringLength(70)]
        public  string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        public bool IsActive { get; set; }

         public virtual ICollection<PrivellageDto> Privillages { get; set; } = new List<PrivellageDto>();

    }
}
