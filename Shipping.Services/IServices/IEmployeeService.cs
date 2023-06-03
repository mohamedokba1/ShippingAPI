using Shipping.Entities.Models;
using Shipping.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Services.IServices
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeReadDto>> Getall();
        Task<EmployeeReadDto> GetByid(Guid id);
        Task Add(EmployeeAddDto employee);
        Task Update(Guid id, EmployeeupdateDto employee);
        Task Delete(Guid id);
        Task Savechanges();
    }
}
