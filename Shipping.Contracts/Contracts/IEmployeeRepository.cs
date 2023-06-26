using Shipping.Entities.Domain.Models;

namespace Shipping.Repositories.Contracts;

public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> Getall();
    Task<Employee?> GetByid(long id);
    Task Add(Employee employee);
    Task Update(long id, Employee? employee);
    Task Delete(long id);
    Task Savechanges();
    IQueryable<Employee> GetEmployeePaginated();
    Task AssignOrderToSales(long salesId, long orderId);

}
