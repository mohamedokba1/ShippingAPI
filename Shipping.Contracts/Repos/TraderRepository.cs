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
    public async Task AddTraderAsync(Trader trader)
    {
        await _context.Set<Trader>().AddAsync(trader);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTraderAsync(Trader trader)
    {
        _context.Set<Trader>().RemoveRange(trader);
        await SaveChangesAsync();
    }

    public async Task<IEnumerable<Trader>> GetAllTradersAsync()
    {
        return await _context.Set<Trader>().Include(trader => trader.Orders).ToListAsync();
    }
    public async Task<Trader?> GetTraderByIdAsync(long traderId)
    {
        return await _context.Set<Trader>()
            .Include(trader => trader.Orders)
            .Include(trader => trader.User).FirstOrDefaultAsync(trader => trader.TraderId == traderId);
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

    public IQueryable<Trader> GetTradersPaginated()
    {
        return _context.Set<Trader>().AsQueryable();
    }

    public async Task<IEnumerable<Trader>> GetFilteredTradersAsync(string searchSrting)
    {
        return await _context.Set<Trader>().Where(trader => trader.UserName.Contains(searchSrting)).ToListAsync();
    }

    public async Task<Trader?> GetTraderByEmailAsync(string traderEmail)
    {
        return await _context.Set<Trader>().FirstOrDefaultAsync(trader => trader.Email == traderEmail);
    }
}
