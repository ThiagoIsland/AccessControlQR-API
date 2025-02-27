using AcessControlQR.Domain.Models;

namespace AcessControlQR.Application.Interfaces;

public interface IQrCodeRepository
{
    public Task<Visitor> GetVisitorByName(string name);
    public Task<Visitor> GetVisitorByEmail(string email);
    public Task<int?> GetIdUser(int id);
    public Task AddAsync(VisitorsQrCode visitorsQrCode);


}