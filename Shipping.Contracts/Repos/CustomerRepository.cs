using Shipping.Entities.Models;
using Shipping.Entities;
using Shipping.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Repositories.Repos
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly ApplicationDbContext _context;
        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Customer> GetAll()
        {
            return _context.Set<Customer>().ToList();
        }

        public Customer? GetById(int id)
        {
            return _context.Set<Customer>().Find(id);
        }
        public void Add(Customer entity)
        {
            _context.Add(entity);
        }
        public void Update(Customer entity)
        {
            _context.Update(entity);
        }
        public void Delete(Customer entity)
        {
            _context.Remove(entity);
        }

    }
}
