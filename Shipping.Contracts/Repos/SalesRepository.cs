using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shipping.Entities;
using Shipping.Entities.Domain.Identity;
using Shipping.Entities.Domain.Models;
using Shipping.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Repositories.Repos
{

    public class SalesRepository : ISalesRepresentativeRepository
    {
        private readonly ApplicationDbContext context;
        public SalesRepository(ApplicationDbContext _context) 
        { 
            context = _context;
        }

        public async Task AddAsync(SalesRepresentative sale)
        {
           await context.AddAsync(sale);
            context.SaveChanges();
            
        }

        public async Task DeleteAsync(string id)
        {
            var salee = await context.Set<SalesRepresentative>().FindAsync(id);
            if (salee != null)
            {
               context.Remove(salee);
                context.SaveChanges();
            }
            await Task.CompletedTask;

        }

        public async Task<IEnumerable<SalesRepresentative>> GetAllAsync()
        {
            return await context.Set<SalesRepresentative>().ToListAsync();
        }

        public async Task<SalesRepresentative?> GetByIdAsync(string id)
        {
            return await context.Set<SalesRepresentative>().FirstOrDefaultAsync(temp => temp.User.Id == id);
        }

        public async Task<SalesRepresentative?> GetByEmailAsync(string email)
        {
            return context.Set<SalesRepresentative>()
                .Include(sr => sr.User)
                .FirstOrDefault(sr => sr.User.Email == email);
        }
        public async Task saveChanges()
        {
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(string id ,SalesRepresentative? sale)
        {
            context.Update(sale);
            await Task.CompletedTask;
        }

    }
}
