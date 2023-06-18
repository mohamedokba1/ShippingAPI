using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Services.Dtos.Branch
{
     public class BranchReadDto
    {
        public int Id { get; set; }
        public string branchName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public bool State { get; set; }
    }
}
