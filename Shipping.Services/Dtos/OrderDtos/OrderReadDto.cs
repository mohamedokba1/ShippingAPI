using Shipping.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Services.Dtos.OrderDtos
{
    public class OrderReadDto
    {
        public OrderState State { get; set; } = OrderState.New;
        public PaymentType PaymentMethod { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime OrderDate { get; set; }
        public double ExtraWeightCost { get; set; }
        public string CompanyBranch { get; set; } = string.Empty;
        public double DefaultCost { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public ShippingType shipping_type { get; set; }
    }
}
