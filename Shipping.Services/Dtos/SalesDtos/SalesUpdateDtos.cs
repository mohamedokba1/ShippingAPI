using Shipping.Entities.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Services.Dtos.SalesDtos
{
    public class SalesUpdateDtos
    {
        [Key]
        public long SalesRepresentative_Id { get; set; }
        [Required]
        [StringLength(70)]
        public string Name { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        [Required]
        [StringLength(11)]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        public double CompanyPercentage { get; set; }
        public string Address { get; set; } = string.Empty;
        [Required]
        [EmailAddress(ErrorMessage = "Entered Email is invalid")]
        public string Email { get; set; } = string.Empty;

        //public virtual ICollection<Goverment> Goverments { get; set; } = new HashSet<Goverment>();
        //public virtual ICollection<Branch> Branchs { get; set; } = new HashSet<Branch>();
        //public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        //public virtual ICollection<Privellge> Privellges { get; set; } = new HashSet<Privellge>();
    }
}
