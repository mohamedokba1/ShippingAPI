using Shipping.Entities.Domain.Models;

namespace Shipping.Repositories.Contracts;

public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> Getall();
    Task<Employee> GetByid(string id);
    Task Add(Employee employee);
    Task Update(string id, Employee employee);
    Task Delete(string id);
    Task Savechanges();
}
