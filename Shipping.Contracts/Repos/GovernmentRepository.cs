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
    public class GovernmentRepository : IGovermentRepository
    {
        private readonly ApplicationDbContext context;

        public GovernmentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Goverment?>> GetRange(List<int> ids)
        {
            return await context.Set<Goverment>().Where(g=> ids.Contains(g.Goverment_Id)).ToListAsync();
        }
        public async Task Add(Goverment goverment)
        {
            await context.Set<Goverment>().AddAsync(goverment);
        }

        public async Task Delete(int id)
        {
            var goverment = GetByid(id);
            context.Remove(goverment);
        }

        public async Task<IEnumerable<Goverment>> Getall()
        {
            return await context.Set<Goverment>().Include(c => c.Cities).ToListAsync();

        }

        public async Task<Goverment> GetByid(int id)
        {
            return (await context.Set<Goverment>().Include(c => c.Cities).FirstOrDefaultAsync(g => g.Goverment_Id == id))!;

        }
        public async Task Savechanges()
        {
             await context.SaveChangesAsync();
        }

        public async Task Update(int id, Goverment? goverment)
        {
            
        }

        public IQueryable<Goverment> GetGovernmentPaginated()
        {
            return context.Set<Goverment>().AsQueryable();

        }
    }
}
