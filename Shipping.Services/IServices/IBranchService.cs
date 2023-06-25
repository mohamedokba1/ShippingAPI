using Shipping.Services.Dtos;
using Shipping.Services.Dtos.Branch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace Shipping.Services.IServices;


  public interface IBranchService
{
    public Task<IEnumerable<BranchReadDto>> GetAllAsync();
    public Task<BranchReadDto>? GetByIdAsync(int id);
    public Task AddAsync(BranchAddDto branchAddDto);
    public Task UpdateAsync(BranchUpdateDto branchUpdateDto, int id);
    public Task DeleteAsync(int id);
    public Task SaveChangesAsync();
    IQueryable<BranchReadDto> GetBranchesPaginated();


}

