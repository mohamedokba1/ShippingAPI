using Shipping.Repositories.Contracts;
using Shipping.Services.IServices;
using Shipping.Services.Dtos;
using Shipping.Entities.Domain.Models;
using AutoMapper;

namespace Shipping.Services.Services;

public class PermissionService : IPermissionService
{
    private readonly IPermissionRepository privellageRepository;
    private readonly IMapper mapper;

    public PermissionService(IPermissionRepository _privellageRepository,IMapper mapper)
    {
        privellageRepository = _privellageRepository;
        this.mapper = mapper;
    }

    public async Task Add(PermissionAddDto privilegedto)
    {
        Permission p = mapper.Map<Permission>(privilegedto);
        await privellageRepository.Add(p);
        await privellageRepository.Savechanges();

    }

    public async Task Delete(int id)
    {
        Permission privFromDb = await privellageRepository.GetByid(id);
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

    public async Task<IEnumerable<PermissionDto>> Getall()
    {
        var privilegesFromDb = await privellageRepository.Getall();
        return mapper.Map<IEnumerable<PermissionDto>>(privilegesFromDb);
    }

    public async Task<PermissionDto> GetByid(int id)
    {
        var privFromDb = await privellageRepository.GetByid(id);
        if(privFromDb == null)
        {
            return null;
        }
        return mapper.Map<PermissionDto>(privFromDb);
    }

    public async Task Savechanges()
    {
        await privellageRepository.Savechanges();

    }

    public async Task Update(int id, PermissionUpdateDto privilegedto)
    {
        Permission privfromdb = await privellageRepository.GetByid(id);
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


