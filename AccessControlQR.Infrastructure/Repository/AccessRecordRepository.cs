using AcessControlQR.Domain.Models;
using AcessControlQR.Infrastructure.Data;
using AcessControlQR.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AcessControlQR.Infrastructure.Repository;

public class AccessRecordRepository : IAccessRecordRepository
{
    private readonly BaseContext _context;

    public AccessRecordRepository(BaseContext context)
    {
        _context = context;
    }

    public async Task<AccessRecord> GetByIdAsync(int id)
    {
        return await _context.AccessRecords.FindAsync(id);
    }

    public async Task<IEnumerable<AccessRecord>> GetAllAsync()
    {
        return await _context.AccessRecords.ToListAsync();
    }

    public async Task AddAsync(AccessRecord accessRecord)
    {
        await _context.AccessRecords.AddAsync(accessRecord);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<AccessRecord>> GetByVisitorIdAsync(int visitorId)
    {
        return await _context.AccessRecords
            .Where(a => a.VisitorId == visitorId)
            .ToListAsync();
    }
}