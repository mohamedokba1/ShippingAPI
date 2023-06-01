using Microsoft.EntityFrameworkCore;
using Shipping.Entities;
using Shipping.Entities.Models;
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
        _context.Traders.Add(trader);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTraderAsync(Trader trader)
    {
        _context.Traders.Remove(trader);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Trader>> GetAllTradersAsync()
    {
        return await _context.Traders.ToListAsync();
    }
    public async Task<Trader?> GetTraderByIdAsync(Guid trader_id)
    {
        return await _context.Traders.FirstOrDefaultAsync(temp => temp.Trader_Id == trader_id);
    }

    public async Task UpdateTraderASync(Trader trader)
    {
        _context.Traders.Update(trader);
        await _context.SaveChangesAsync();
    }

    public Task UpdateTraderASync(Guid trderId, Trader trader)
    {
        throw new NotImplementedException();
    }
}
