using Shipping.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Services.IServices
{
    public interface IGovernmentService
    {
        Task<IEnumerable<GovermentReadDto>> Getall();
        Task<GovermentReadDto> GetByid(int id);
        Task Add(GovermentAddDto goverment);
        Task Update(int id,GovermentUpdateDto goverment);
        Task Delete(int id);
        Task Savechanges();

    }
}
