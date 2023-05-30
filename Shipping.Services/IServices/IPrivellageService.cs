using Shipping.Entities.Models;
using Shipping.Services.Dtos.PrivellageDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Services.IServices
{
    public interface IPrivellageService
    {
        Task<IEnumerable<PrivellageDto>> GetAllAsync();
        Task<PrivellageDto> GetByIdAsync(Guid id);
        Task AddAsync(PrivellageDto privellgeDto);
        Task UpdateAsync(PrivellageDto privellgeDto, Guid id);
        Task DeleteAsync(Guid id);
    }
}
