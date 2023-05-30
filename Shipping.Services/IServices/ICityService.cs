using Shipping.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Services.IServices
{
    public interface ICityService
    {
        public Task<IEnumerable<City>> GetAllAsync();
        public Task<City>? GetByIdAsync(int id);
        public Task AddAsync(City city);
        public Task UpdateAsync(City city, int id);
        public Task DeleteAsync(int id);
        public Task SaveChangesAsync();
    }
}
