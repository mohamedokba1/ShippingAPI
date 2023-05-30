using Shipping.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Services.IServices
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> GetProductsAsync();
        
        public Task<Product> GetProductByIdAsync(int id);
        public Task AddAsync(Product product);
        public Task UpdateAsync(Product product);
        public Task DeleteAsync(int id);
        

    }
}
