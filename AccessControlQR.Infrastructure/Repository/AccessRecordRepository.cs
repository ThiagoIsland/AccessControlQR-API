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
    public async Task<string> GetStatus(int IDVisitor)
    {
        var status = await _context.Visitors.FindAsync(IDVisitor);
        return status.Status;
    }

    public async Task<int> GetUserID(string name)
    {
        var userId = await _context.Users.FirstOrDefaultAsync(prop => prop.Username == name);

        return userId.Id;
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