using Microsoft.EntityFrameworkCore;
using Shipping.Entities;
using Shipping.Entities.Domain.Models;
using Shipping.Repositories.Contracts;

namespace Shipping.Repositories.Repos
{
    public class PrivellgeRepository : IPermissionRepository
    {
        private readonly ApplicationDbContext context;

        public PrivellgeRepository(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task Add(Permission privilege)
        {
            await context.Privellges.AddAsync(privilege);
        }

        public async Task Delete(int id)
        {
            var privilege = await GetByid(id);
            context.Privellges.Remove(privilege);
        }

        public async Task<IEnumerable<Permission>> Getall()
        {
            return await context.Privellges.ToListAsync();
        }

        public async Task<Permission?> GetByid(int id)
        {
            return await context.Privellges.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Savechanges()
        {
            await context.SaveChangesAsync();
        }

        public async Task Update(int id, Permission privilege)
        {

        }
    }
}