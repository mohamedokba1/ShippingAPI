using Microsoft.EntityFrameworkCore;
using Shipping.Entities;
using Shipping.Entities.Domain.Models;
using Shipping.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Repositories.Repos
{


    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext context;

        public ProductRepository(ApplicationDbContext _context)
        {
            context = _context;
        }
        

        public async Task AddAsync(Product product)
        {
            await context.Set<Product>().AddAsync(product);   
             
        }

        public async Task DeleteAsync(Product product)
        {
            //var pro =await context.Set<Product>().FindAsync(product);
            //if (pro != null)
            //{
            //   context.Remove(pro);
            //}
            //await Task.CompletedTask;
            context.Set<Product>().Remove(product);
            await Task.CompletedTask;
        }

       
       

        public  async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await context.Set<Product>().ToListAsync();
        }



        public async Task<Product>? GetByIdAsync(Guid id)
        {
            return await context.Set<Product>().FindAsync(id);
        }

        public async Task saveChanges()
        {
            context.SaveChanges();
            
        }

        public async Task UpdateAsync(Guid id, Product? product)
        {
            //context.Set<Product>().Update(product);

            //await Task.CompletedTask;
            context.SaveChanges();
        }
    }
}
