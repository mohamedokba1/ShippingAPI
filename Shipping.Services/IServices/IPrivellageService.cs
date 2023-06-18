using Shipping.Services.Dtos;

namespace Shipping.Services.IServices;

public interface IPrivellageService
{
    Task<IEnumerable<PrivellageDto>> Getall();
    Task<PrivellageDto> GetByid(int id);
    Task Add(PrivilegeAddDto privilege);
    Task Update(int id, PrivllageUpdateDto privilege);
    Task Delete(int id);
    Task Savechanges();
}
