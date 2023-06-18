using Shipping.Entities.Domain.Models;

namespace Shipping.Repositories.Contracts;

public interface IPrivellageRepository
{
    Task<IEnumerable<Privellge>> Getall();
    Task<Privellge?> GetByid(int id);
    Task Add(Privellge privilege);
    Task Update(int id, Privellge privilege);
    Task Delete(int id);
    Task Savechanges();
}
