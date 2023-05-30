using Shipping.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Services.IServices
{
    public interface ISalesService
    {
      
        public Task<IEnumerable<SalesRepresentative>> GetAllSalesAsync();

        public Task<SalesRepresentative> GetSaleByIdAsync(int id);
        public Task AddAsync(SalesRepresentative sale);
        public Task UpdateAsync(SalesRepresentative sale);
        public Task DeleteAsync(int id);
    }
}
