using Shipping.Entities.Domain.Models;

namespace Shipping.Repositories.Contracts;

public interface IPermissionRepository
{
    Task<IEnumerable<Permission>> Getall();
    Task<Permission?> GetByid(int id);
    Task Add(Permission privilege);
    Task Update(int id, Permission privilege);
    Task Delete(int id);
    Task Savechanges();
}
