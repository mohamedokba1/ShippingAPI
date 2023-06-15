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
        private readonly UserManager<ApplicationUser> _userManager;
        public SalesRepository(ApplicationDbContext _context, UserManager<ApplicationUser> userManager) 
        { 
            context = _context;
            _userManager = userManager;
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
            var user = await _userManager.FindByIdAsync(id);
            return user as SalesRepresentative;
        }

        public async Task<SalesRepresentative?> GetByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user as SalesRepresentative;
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
