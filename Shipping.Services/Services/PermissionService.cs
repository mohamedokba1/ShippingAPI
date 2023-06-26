using Shipping.Services.IServices;
using Shipping.Services.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Shipping.Entities.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Shipping.Services.Dtos.PrermissionDtos;

namespace Shipping.Services.Services;

public class PermissionService : IPermissionService
{
    private readonly RoleManager<ApplicationUserRole> _roleManager;
    private readonly IMapper _mapper;

    public PermissionService(
        RoleManager<ApplicationUserRole> roleManager
        ,IMapper mapper)
    {
        _roleManager = roleManager;
        _mapper = mapper;
    }
    public async Task<IEnumerable<PermissionResponseDto>> Getall()
    {
        List<PermissionResponseDto> result = new List<PermissionResponseDto>();
        var roles =  await _roleManager.Roles.ToListAsync();
        foreach (var role in roles)
        {
            var claims = await _roleManager.GetClaimsAsync(role);
            result.Add(new PermissionResponseDto
            {
                Id = role.Id,
                Name = role.Name,
              Date = role.Date,
                Claims = _mapper.Map<IList<ClaimDto>>(claims)
            });
        }
        return result;
    }
    public async Task<PermissionResponseDto?> GetByid(string roleId)
    {
        ApplicationUserRole? role = await _roleManager.FindByIdAsync(roleId);
        if(role != null)
        {
            return new PermissionResponseDto()
            {
                Id = roleId,
                Name = role?.Name,
                Date = role?.Date,
                Claims = _mapper.Map<IList<ClaimDto>>(await _roleManager.GetClaimsAsync(role))
            };
        }
        return null;
    }
    public async Task Add(PermissionAddDto permissionAddDto)
    {
        var newRole = new ApplicationUserRole
        {
            Date = permissionAddDto.Date,
            Name = permissionAddDto.Name,
            NormalizedName = permissionAddDto.Name.ToUpper(),
            
        };
        var result = await _roleManager.CreateAsync(newRole);
            
        if(result.Succeeded)
        {
            foreach (var claim in permissionAddDto.Claims)
            {
                await _roleManager.AddClaimAsync(newRole, new Claim(claim, "true"));
            }
        }
        else
            throw new Exception("failed to add new role");
    }

    public async Task<bool> Delete(string roleId)
    {
        ApplicationUserRole? role = await _roleManager.FindByIdAsync(roleId);
        if(role != null)
        {
            await _roleManager.DeleteAsync(role);
            return true;
        }
        return false;
    }

    public async Task<bool> Update(string id, PermissionUpdateDto permissionUpdateDto)
    {
        ApplicationUserRole? role = await _roleManager.FindByIdAsync(id);
        if(role != null)

        { 
            role.Name = permissionUpdateDto.Name;

            var claims =  await _roleManager.GetClaimsAsync(role);
            foreach(var claim in claims)
            {
                await _roleManager.RemoveClaimAsync(role, claim);
            }
            foreach(var claim in permissionUpdateDto.Claims)
            {
                await _roleManager.AddClaimAsync(role, new Claim(claim, "true"));
            }
            return true;
        }
        return false;
    }
}