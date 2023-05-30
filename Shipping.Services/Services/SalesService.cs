using Shipping.Entities.Models;
using Shipping.Repositories.Contracts;
using Shipping.Repositories.Repos;
using Shipping.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Services.Services
{
    public class SalesService : ISalesService
    {
        private readonly ISalesRepresentativeRepository _salesRepository;
        public SalesService(ISalesRepresentativeRepository salesRepository)
        {
            _salesRepository = salesRepository;
        }
        public Task AddAsync(SalesRepresentative sale)
        {
           return _salesRepository.AddAsync(sale);
        }

        public async Task DeleteAsync(int id)
        {
            var sale = await _salesRepository.GetByIdAsync(id);
            if (sale != null)
            {
                await _salesRepository.DeleteAsync(sale);
            }
        }

        public Task<IEnumerable<SalesRepresentative>> GetAllSalesAsync()
        {
            return _salesRepository.GetAllAsync();
        }

        public Task<SalesRepresentative> GetSaleByIdAsync(int id)
        {
            return _salesRepository.GetByIdAsync(id);
        }

        public Task UpdateAsync(SalesRepresentative sale)
        {
            return _salesRepository.UpdateAsync(sale);
        }
    }
}
