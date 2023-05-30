using System.Net.Sockets;
using Shipping.Entities.Models;

namespace Shipping.Repositories;

public interface ICityRepository
{
    IEnumerable<City> GetAll();
    City? GetById(int id);
    void Add(City entity);
    void Update(City entity);
    void Delete(City entity);
}
