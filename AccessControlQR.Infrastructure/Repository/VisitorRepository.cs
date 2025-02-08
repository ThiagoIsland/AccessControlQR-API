using AcessControlQR.Domain.Models;
using AcessControlQR.Infrastructure.Data;
using AcessControlQR.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AcessControlQR.Infrastructure.Repository;

public class VisitorRepository : IVisitorRepository
{
    private readonly BaseContext _context;

    public VisitorRepository(BaseContext context)
    {
        _context = context;
    }

    public async Task<Visitor> GetByIdAsync(int id)
    {
        return await _context.Visitors.FindAsync(id);
    }

    public async Task<Visitor> GetByQRCodeAsync(string qrCode)
    {
        return await _context.Visitors
            .FirstOrDefaultAsync(v => v.QRCode == qrCode);
    }

    public async Task<IEnumerable<Visitor>> GetAllAsync()
    {
        return await _context.Visitors.ToListAsync();
    }

    public async Task AddAsync(Visitor visitor)
    {
        await _context.Visitors.AddAsync(visitor);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Visitor visitor)
    {
        _context.Visitors.Update(visitor);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var visitor = await GetByIdAsync(id);
        if (visitor != null)
        {
            _context.Visitors.Remove(visitor);
            await _context.SaveChangesAsync();
        }
    }
}