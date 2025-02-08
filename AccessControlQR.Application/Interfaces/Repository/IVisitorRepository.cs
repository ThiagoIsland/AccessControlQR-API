using AcessControlQR.Domain.Models;


namespace AcessControlQR.Application.Interfaces;

public interface IVisitorRepository
{
    Task<Visitor> GetByIdAsync(int id);
    Task<Visitor> GetByQRCodeAsync(string qrCode);
    Task<IEnumerable<Visitor>> GetAllAsync();
    Task AddAsync(Visitor visitor);
    Task UpdateAsync(Visitor visitor);
    Task DeleteAsync(int id);
}