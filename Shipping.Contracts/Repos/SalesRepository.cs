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
            
        }

        

        public async Task DeleteAsync(SalesRepresentative sale)
        {
            var salee = await context.Set<SalesRepresentative>().FindAsync(sale);
            if (salee != null)
            {
               context.Remove(salee);
            }
            await Task.CompletedTask;

        }



        public async Task<IEnumerable<SalesRepresentative>> GetAllAsync()
        {
            return await context.Set<SalesRepresentative>().ToListAsync();
        }



        public async Task<SalesRepresentative>? GetByIdAsync(Guid id)
        {
            return await  context.Set<SalesRepresentative>().FindAsync(id);
        }



        public async Task UpdateAsync(Guid id ,SalesRepresentative? sale)
        {
            //context.Update(sale);
            //await Task.CompletedTask;
        }

        
    }
}
