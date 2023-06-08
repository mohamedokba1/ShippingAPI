using Shipping.Entities.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Services.Dtos.ProductDtos
{
    public  class ProductReadDtos
    {
        [Required]
        [StringLength(50, ErrorMessage = "Product Name is not valid ")]
        public string ProductName { get; set; } = string.Empty;
        [Required]

        public double Weight { get; set; }
        [Required]
        public double Price { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
