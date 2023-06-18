﻿using Shipping.Entities.Domain.Models;

namespace Shipping.Services.Dtos;
public class CityReadDto
{
    public int CityId { get; set; }
    public string CityName { get; set; }=string.Empty;
    public double NormalShippingCost { get; set; }
    public double PickupShippingCost { get; set; }
    //public virtual GovermentReadDto? goverment { get; set; }
    public string govermentName { get; set; }
}
