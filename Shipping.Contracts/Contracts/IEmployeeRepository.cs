using Shipping.Entities.Models;

namespace Shipping.Repositories.Contracts;

public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> Getall();
    Task<Employee> GetByid(Guid id);
    Task Add(Employee employee);
    Task Update(Guid id, Employee employee);
    Task Delete(Guid id);
    Task Savechanges();
}
