using Shipping.Services.Dtos;

namespace Shipping.Services.IServices
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeReadDto>> Getall();
        Task<EmployeeReadDto> GetByid(long id);
        Task Add(EmployeeAddDto employee);
        Task Update(long id, EmployeeupdateDto employee);
        Task Delete(long id);
        Task Savechanges();
    }
}
