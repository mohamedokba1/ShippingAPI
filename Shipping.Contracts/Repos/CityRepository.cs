using Shipping.Entities;
using Shipping.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Repositories.Repos
{
    public class CityRepository:ICityRepository
    {
        private readonly ApplicationDbContext _context;
        public CityRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<City> GetAll()
        {
            return _context.Set<City>().ToList();
        }

        public City? GetById(int id)
        {
            return _context.Set<City>().Find(id);
        }
        public void Add(City entity)
        {
            _context.Add(entity);
        }
        public void Update(City entity)
        {
            _context.Update(entity);
        }
        public void Delete(City entity)
        {
            _context.Remove(entity);
        }
    }
}
