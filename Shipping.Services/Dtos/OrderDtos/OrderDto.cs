using Shipping.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Services.Dtos.OrderDtos
{
    public class OrderDto
    {

        public PaymentType PaymentMethod { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime OrderDate { get; set; }
        public double ExtraWeightCost { get; set; }
        public string CompanyBranch { get; set; } = string.Empty;
        public double DefaultCost { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public ShippingType shipping_type { get; set; }


        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
        public virtual Trader traderId { get; set; }
        public virtual SalesRepresentative salesRepresentativeId { get; set; }
    }
}
