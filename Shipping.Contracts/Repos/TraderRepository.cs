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
    public async Task AddTrader(Trader trader)
    {
        _context.Traders.Add(trader);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTrader(Trader trader)
    {
        _context.Traders.Remove(trader);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Trader>> GetAllTtraders()
    {
        return await _context.Traders.ToListAsync();
    }

    public async Task<Trader?> GetTraderById(Guid trader_id)
    {
        return await _context.Traders.FirstOrDefaultAsync(temp => temp.Trader_Id == trader_id);
    }

    public async Task UpdateTrader(Trader trader)
    {
        _context.Traders.Update(trader);
        await _context.SaveChangesAsync();
    }
}
