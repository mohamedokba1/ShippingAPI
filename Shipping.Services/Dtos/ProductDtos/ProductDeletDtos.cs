using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Services.Dtos.ProductDtos
{
    public class ProductDeletDtos
    {
        [Required]
        public Guid Product_Id { get; set; }
    }
}
