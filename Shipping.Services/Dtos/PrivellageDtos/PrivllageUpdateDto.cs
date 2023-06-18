using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Services.Dtos; 

public  class PrivllageUpdateDto
{
    public int Privellge_Id { get; set; }
    public string PrivellgeName { get; set; } = string.Empty;
    public DateTime date { get; set; }
}
