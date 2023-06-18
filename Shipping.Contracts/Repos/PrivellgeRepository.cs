using Microsoft.EntityFrameworkCore;
using Shipping.Entities;
using Shipping.Entities.Domain.Models;
using Shipping.Entities.Migrations;
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
        private readonly ApplicationDbContext context;

        public PrivellgeRepository(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task Add(Privellge privilege)
        {
            await context.Privellges.AddAsync(privilege);
        }

        public async Task Delete(int id)
        {

                var privilege =    await GetByid(id);
                context.Privellges.Remove(privilege);
        }

        public async Task<IEnumerable<Privellge>> Getall()
        {
            return await context.Privellges.ToListAsync();
        }

        public async Task<Privellge?> GetByid(int id)
        {
            return await context.Privellges.FirstOrDefaultAsync(e => e.Privellge_Id == id);
        }

        public async Task Savechanges()
        {
           await context.SaveChangesAsync();
        }

        public async Task Update(int id, Privellge privilege)
        {

        }



        //public async Task Add(Privellge privellge)
        //{
        //    await context.Privellges.AddAsync(privellge);
        //}

        //public async Task Delete(long id)
        //{
        //    var privilege =    await GetByid(id);
        //    context.Privellges.Remove(privilege);
        //}

        //public async Task<IEnumerable<Privellge>> Getall()
        //{
        //    return await context.Privellges.ToListAsync();

        //}

        //public async Task<Privellge?> GetByid(long id)
        //{
        //    return await context.Set<Privellge>().FirstOrDefaultAsync(e => e.Privellge_Id == id);
        //}

        //public async Task Savechanges()
        //{
        //    await context.SaveChangesAsync();
        //}

        //public async Task Update(long id, Privellge privellge)
        //{

        //}



    }
}