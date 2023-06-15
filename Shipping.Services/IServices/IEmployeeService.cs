using Shipping.Services.Dtos;

namespace Shipping.Services.IServices
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeReadDto>> Getall();
        Task<EmployeeReadDto> GetByid(string id);
        Task Add(EmployeeAddDto employee);
        Task Update(string id, EmployeeupdateDto employee);
        Task Delete(string id);
        Task Savechanges();
    }
}
