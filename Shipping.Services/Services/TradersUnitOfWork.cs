using Microsoft.AspNetCore.Identity;
using Shipping.Entities;
using Shipping.Entities.Domain.Identity;
using Shipping.Entities.Domain.Models;
using Shipping.Services.IServices;

namespace Shipping.Services.Services;

public class UnitOfWork : IUnitOfWork<Trader>
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task AddUserAndEntity(ApplicationUser user, Trader entity)
    {
        await _context.Set<Trader>().AddAsync(entity);
        await _userManager.CreateAsync(user);
    }

    public async Task CommitChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
