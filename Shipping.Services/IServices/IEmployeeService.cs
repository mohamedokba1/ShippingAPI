using Shipping.Services.Dtos;

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
