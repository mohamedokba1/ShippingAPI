using Shipping.Services.Dtos;

namespace Shipping.Services.IServices;

public interface IPermissionService
{
    Task<IEnumerable<PermissionResponseDto>> Getall();
    Task<PermissionResponseDto?> GetByid(string id);
    Task Add(PermissionAddDto privilege);
    Task<bool> Update(string id, PermissionUpdateDto permissionUpdateDto);
    Task<bool> Delete(string id);
}
