using Shipping.Entities.Domain.Models;

namespace Shipping.Repositories.Contracts;

public interface IGovermentRepository
{
    Task<IEnumerable<Goverment>> Getall();
    Task<Goverment> GetByid(int id);
    Task Add(Goverment goverment);
    Task Update(int id, Goverment goverment);
    Task Delete(int id);
    Task Savechanges();
    Task<IEnumerable<Goverment?>> GetRange(List<int> ids);
    IQueryable<Goverment> GetGovernmentPaginated();

}
