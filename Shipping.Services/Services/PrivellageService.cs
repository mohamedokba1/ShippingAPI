using Shipping.Entities.Models;
using Shipping.Repositories.Contracts;
using Shipping.Services.IServices;
using Shipping.Services.Validations;
using Shipping.Services.Dtos;

namespace Shipping.Services.Services;

public class PrivellageService : IPrivellageService
{
    private readonly IPrivellageRepository privellageRepository;

    public PrivellageService(IPrivellageRepository _privellageRepository)
    {
        privellageRepository = _privellageRepository;
    }
    public async Task AddAsync(PrivellageDto privellgeDto)
    {
        if(privellgeDto != null)
        {
            Privellge? privellage = new Privellge
            {
                PrivellgeName = privellgeDto.PrivellgeName,
            };
            ValidateModel.ModelValidation(privellage);
            await privellageRepository.AddAsync(privellage);
            await privellageRepository.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        var privellge = await privellageRepository.GetByIdAsync(id);
        if (privellge != null)
        {
            ValidateModel.ModelValidation(privellge);

            await privellageRepository.DeleteAsync(privellge);
            await privellageRepository.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<PrivellageDto>> GetAllAsync()
    {
        var privellges = await privellageRepository.GetAllAsync();
        return privellges.Select(p => new PrivellageDto
        {
           PrivellgeName = p.PrivellgeName
        });
    }

    public async Task<PrivellageDto> GetByIdAsync(Guid id)
    {
        var privellge = await privellageRepository.GetByIdAsync(id);
        if (privellge != null)
        {
            return new PrivellageDto
            {
                PrivellgeName = privellge.PrivellgeName
            };
        }
        return null;
    }

    public async Task UpdateAsync(PrivellageDto privellgeDto, Guid id)
    {
        if (privellgeDto != null)
        {
            Privellge? privellge = await privellageRepository.GetByIdAsync(id);
            if (privellge != null)
            {
                privellge.PrivellgeName = privellgeDto.PrivellgeName;
                ValidateModel.ModelValidation(privellge);

                await privellageRepository.UpdateAsync(privellge);
                await privellageRepository.SaveChangesAsync();
            }
        }
    }
}
