using Shipping.Services.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Shipping.Services.IServices
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeReadDto>> Getall();
        Task<EmployeeReadDto> GetByid(long id);
        Task<List<ValidationResult>> Add(EmployeeAddDto employee);
        Task Update(long id, EmployeeupdateDto employee);
        Task Delete(long id);
        Task Savechanges();
    }
}
