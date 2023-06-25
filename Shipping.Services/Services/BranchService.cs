using AutoMapper;
using AutoMapper.QueryableExtensions;
using Shipping.Entities.Domain.Models;
using Shipping.Repositories;
using Shipping.Services.Dtos;
using Shipping.Services.IServices;
using Shipping.Services.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class BranchService: IBranchService
{
    private readonly IBranchRepository _branchRepository;
    private readonly IMapper _mapper;

    public BranchService(IBranchRepository branchRepository, IMapper mapper)
    {
        _branchRepository = branchRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<BranchReadDto>> GetAllAsync()
    {
        var branches = await _branchRepository.GetAllAsync();
        return branches.Select(branch => new BranchReadDto
        {
            Id = branch.Id, 
            branchName = branch.BranchName,
            State = branch.State,
            CreatedAt = branch.CreatedAt
        });
    }
    public async Task<BranchReadDto> GetByIdAsync(int id)
    {
        var branch = await _branchRepository.GetByIdAsync(id);
        if (branch != null)
        {
            return new BranchReadDto
            {
                Id=branch.Id,
                branchName = branch.BranchName,
                State = branch.State,
                CreatedAt = branch.CreatedAt
            };
        }
        return null!;
    }
    public async Task AddAsync(BranchAddDto branchAddDto)
    {
        if (branchAddDto != null)
        {
            var branch = new Branch
            {
                BranchName = branchAddDto.branchName,
                State = branchAddDto.State,
                CreatedAt = branchAddDto.CreatedAt
            };
        
            ValidateModel.ModelValidation(branch);

            await _branchRepository.AddAsync(branch);
            await _branchRepository.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(BranchUpdateDto branchUpdateDto, int id)
    {

        if (branchUpdateDto != null)
        {
            var branch = await _branchRepository.GetByIdAsync(id);
            if (branch != null)
            {
                branch.BranchName = branchUpdateDto.branchName;
                branch.CreatedAt= branchUpdateDto.CreatedAt;

                ValidateModel.ModelValidation(branch);

                await _branchRepository.UpdateAsync(branch);
                await _branchRepository.SaveChangesAsync();
            }
        }
    }
    public async Task DeleteAsync(int id)
    {
        var branch = await _branchRepository.GetByIdAsync(id);
        if (branch != null)
        {
            ValidateModel.ModelValidation(branch);

            await _branchRepository.DeleteAsync(branch);
            await _branchRepository.SaveChangesAsync();
        }
    }
    public async Task SaveChangesAsync()
    {
        await _branchRepository.SaveChangesAsync();
    }

    public IQueryable<BranchReadDto> GetBranchesPaginated()
    {
        IQueryable branches = _branchRepository.GetBranchPaginated();
        return branches.ProjectTo<BranchReadDto>(_mapper.ConfigurationProvider);
    }
}
