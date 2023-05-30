using Shipping.Entities.Models;
using Shipping.Entities;
using Shipping.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Shipping.Repositories.Repos
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly ApplicationDbContext _context;
        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Set<Customer>().ToListAsync();
        }

        public async Task<Customer>? GetByIdAsync(int id)
        {
            return await _context.Set<Customer>().FindAsync(id);
        }
        public async Task AddAsync(Customer entity)
        {
            await _context.AddAsync(entity);
        }
        public async Task UpdateAsync(Customer entity)
        {
            _context.Update(entity);
            await Task.CompletedTask;
        }
        public async Task DeleteAsync(Customer entity)
        {
            var city = await _cityRepository.GetByIdAsync(id);
        if (city != null)
        {
            await _cityRepository.DeleteAsync(city);
        }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
