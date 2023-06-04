using Microsoft.EntityFrameworkCore;
using Shipping.Entities;
using Shipping.Entities.Domain.Models;
using Shipping.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Repositories.Repos
{
    public class PrivellgeRepository : IPrivellageRepository
    {
        public ApplicationDbContext context { get; }

        public PrivellgeRepository(ApplicationDbContext _context)
        {
            context = _context;
        }
        public  async Task<IEnumerable<Privellge>> GetAllAsync()
        {
            return await context.Set<Privellge>().ToListAsync();
        }

        public async Task<Privellge> GetByIdAsync(Guid id)
        {
            return await context.Set<Privellge>().FindAsync(id);
        }

        public async Task AddAsync(Privellge privellge)
        {
             await context.Set<Privellge>().AddAsync(privellge);
        }

        public async Task UpdateAsync(Privellge privellge)
        {
             context.Set<Privellge>().Update(privellge);
             await Task.CompletedTask;

        }

        public async Task DeleteAsync(Privellge privellge)
        {
            context.Set<Privellge>().Remove(privellge);
            await Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

    }
}
