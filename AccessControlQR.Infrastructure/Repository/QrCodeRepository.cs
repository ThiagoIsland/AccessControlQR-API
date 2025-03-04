using AcessControlQR.Application.Interfaces;
using AcessControlQR.Domain.Models;
using AcessControlQR.Infrastructure.Data;

namespace AcessControlQR.Infrastructure.Repository;

public class QrCodeRepository : IQrCodeRepository
{
    private readonly BaseContext _context;

    public QrCodeRepository(BaseContext context)
    {
        _context = context;
    }
    public async Task<Visitor> GetVisitorByName(string name)
    {
        return await _context.Visitors.FindAsync(name);
    }
    public async Task<Visitor> GetVisitorByEmail(string email)
    {
        return await _context.Visitors.FindAsync(email);
    }

    public async Task<string> ValidateStatus(int id)
    {
        var status = await _context.Visitors.FindAsync(id);
        return status.Status;
    }
    
    public async Task<VisitorsQrCode> GetQrCodeByScanned(string scannedQrCode)
    {
        return await _context.VisitorsQrCodes.FindAsync(scannedQrCode);
    }
    public async Task<int?> GetIdUser(int id)
    {
        var user = await _context.Visitors.FindAsync(id);
        return user?.Id;
    }

    public async Task<string> GetQrCode(string name)
    {
        var content = await _context.VisitorsQrCodes.FindAsync(name);
        return content.QrCode;
    }

    public async Task AddAsync(VisitorsQrCode visitorsQrCode)
    {
        await _context.VisitorsQrCodes.AddAsync(visitorsQrCode);
        await _context.SaveChangesAsync();
    }
    
}