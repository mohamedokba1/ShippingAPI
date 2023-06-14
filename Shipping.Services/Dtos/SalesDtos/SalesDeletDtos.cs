using Shipping.Entities.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Services.Dtos.SalesDtos
{
    public class SalesDeletDtos
    {
        [Key]
        public long SalesRepresentative_Id { get; set; }
        
    }
}
