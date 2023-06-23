using Shipping.Services.Dtos;

namespace Shipping.Services.IServices;

public interface IPermissionService
{
    Task<IEnumerable<PermissionDto>> Getall();
    Task<PermissionDto> GetByid(int id);
    Task Add(PermissionAddDto privilege);
    Task Update(int id, PermissionUpdateDto privilege);
    Task Delete(int id);
    Task Savechanges();
}
