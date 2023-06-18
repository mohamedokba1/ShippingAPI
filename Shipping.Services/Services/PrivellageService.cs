using Shipping.Repositories.Contracts;
using Shipping.Services.IServices;
using Shipping.Services.Dtos;
using Shipping.Entities.Domain.Models;
using AutoMapper;

namespace Shipping.Services.Services;

public class PrivellageService : IPrivellageService
{
    private readonly IPrivellageRepository privellageRepository;
    private readonly IMapper mapper;

    public PrivellageService(IPrivellageRepository _privellageRepository,IMapper mapper)
    {
        privellageRepository = _privellageRepository;
        this.mapper = mapper;
    }

    public async Task Add(PrivilegeAddDto privilegedto)
    {
        Privellge p = mapper.Map<Privellge>(privilegedto);
        await privellageRepository.Add(p);
        await privellageRepository.Savechanges();

    }

    public async Task Delete(int id)
    {
        Privellge privFromDb = await privellageRepository.GetByid(id);
        if(privFromDb != null)
        {
            await privellageRepository.Delete(id);
            await privellageRepository.Savechanges();

        }
        else
        {
            throw new Exception("this privilege not found");
        }
    }

    public async Task<IEnumerable<PrivellageDto>> Getall()
    {
        var privilegesFromDb = await privellageRepository.Getall();
        return mapper.Map<IEnumerable<PrivellageDto>>(privilegesFromDb);
    }

    public async Task<PrivellageDto> GetByid(int id)
    {
        var privFromDb = await privellageRepository.GetByid(id);
        if(privFromDb == null)
        {
            return null;
        }
        return mapper.Map<PrivellageDto>(privFromDb);
    }

    public async Task Savechanges()
    {
        await privellageRepository.Savechanges();

    }

    public async Task Update(int id, PrivllageUpdateDto privilegedto)
    {
        Privellge privfromdb = await privellageRepository.GetByid(id);
        if(privfromdb != null)
        {
            mapper.Map(privilegedto, privfromdb);
            await privellageRepository.Savechanges();
        }
        else
        {
            throw new Exception("this privilege is not found");
        }
    }
}


