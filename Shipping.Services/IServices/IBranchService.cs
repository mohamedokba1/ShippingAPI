using Shipping.Services.Dtos;
using Shipping.Services.Dtos.Branch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Services.IServices
{
    public interface IBranchService
    {
        Task<IEnumerable<BranchReadDto>> Getall();

    }
}
