using AcessControlQR.Domain.Models;

namespace AcessControlQR.Application.Interfaces;

public interface IQrCodeRepository
{
    public Task<Visitor> GetVisitorByName(string name);
    public Task<Visitor> GetVisitorByEmail(string email);
    public Task<VisitorsQrCode> GetQrCodeByScanned(string scannedQrCode);
    public Task<string> ValidateStatus(int id);
    public Task<int?> GetIdUser(int id);
    public Task<string> GetQrCode(string name); 
    public Task AddAsync(VisitorsQrCode visitorsQrCode);


}