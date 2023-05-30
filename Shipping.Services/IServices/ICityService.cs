using Shipping.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ICityService
{
    public Task<IEnumerable<CityReadDto>> GetAllAsync();
    public Task<CityReadDto>? GetByIdAsync(int id);
    public Task AddAsync(CityAddDto cityAddDto);
    public Task UpdateAsync(CityUpdateDto cityUpdateDto, int id);
    public Task DeleteAsync(CityDeleteDto cityDeleteDto);
    public Task SaveChangesAsync();
}
