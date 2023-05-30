using Shipping.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Services.Dtos.SalesDtos
{
    public class AddSalesDto
    {
        public Guid SalesRepresentative_Id { get; set; }
        [Required]
        [StringLength(70)]
        public string Name { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        [Required]
        [StringLength(11)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        public double CompanyPercentage { get; set; }
        public string Address { get; set; } = string.Empty;
        [Required]
        public string Goverment { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        public virtual ICollection<Privellge> Privellges { get; set; } = new List<Privellge>();


       
        }
    }
}
