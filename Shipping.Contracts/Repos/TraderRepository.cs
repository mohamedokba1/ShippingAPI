using Microsoft.EntityFrameworkCore;
using Shipping.Entities;
using Shipping.Entities.Domain.Models;
using Shipping.Repositories.Contracts;

namespace Shipping.Repositories.Repos;

public class TraderRepository : ITraderRepository
{
    private readonly ApplicationDbContext _context;
    public TraderRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Trader?> AddTraderAsync(Trader trader)
    {
        _context.Set<Trader>().Add(trader);
        int result = await _context.SaveChangesAsync();
        if(result == 1)
            return trader;
        return null;
    }

    public async Task DeleteTraderAsync(Trader trader)
    {
        _context.Set<Trader>().RemoveRange(trader);
        await SaveChangesAsync();
    }

    public async Task<IEnumerable<Trader>> GetAllTradersAsync()
    {
        return await _context.Set<Trader>().ToListAsync();
    }
    public async Task<Trader?> GetTraderByIdAsync(Guid trader_id)
    {
        return await _context.Set<Trader>().FirstOrDefaultAsync(temp => temp.Trader_Id == trader_id);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Trader trader)
    {
        _context.Set<Trader>().Update(trader);
        await Task.CompletedTask;
    }
}
