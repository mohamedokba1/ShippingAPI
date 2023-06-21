using Microsoft.Identity.Client;
using Shipping.Entities.Domain.Identity;
using Shipping.Entities.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Services.Dtos.SalesDtos
{
    public class SalesReadDtos
    {
        public long SalesRepresentativeId { get; set; }


        public string Name { get; set; } = string.Empty;
        
        public  string UserName { get; set; } = string.Empty;

        public string password { get; set; } = string.Empty;


        public  string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public double CompanyPercentage { get; set; }

        public DiscountType discountType { get; set; }
        public bool IsActive { get; set; }


        public ICollection<BranchReadDto>? Branches { get; set; } 
        public ICollection<GovermentReadDto>? Goverments { get; set; }   

    }
}
