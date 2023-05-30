using Shipping.Entities.Models;

namespace Shipping.Repositories.Contracts;

public interface ICustomerRepository
{
    IEnumerable<Customer> GetAll();
    Customer? GetById(int id);
    void Add(Customer entity);
    void Update(Customer entity);
    void Delete(Customer entity);
}
