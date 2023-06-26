using Shipping.Services.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Shipping.Services.IServices
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeReadDto>> Getall();
        Task<EmployeeReadDto> GetByid(long id);
        Task<List<ValidationResult>?> AddUserAndEmployee(EmployeeAddDto employee);
        Task Update(long id, EmployeeupdateDto employee);
        Task Delete(long id);
        Task Savechanges();
        IQueryable<EmployeeReadDto> GetEmployeesPaginated();
        Task AssignOrderToSales(long salesId, long orderId);

    }
}
