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
            await saveChanges();
             
        }

        public async Task DeleteAsync(Product product)
        {
          
            context.Set<Product>().Remove(product);
            await saveChanges();
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

            await saveChanges();
        }
    }
}
