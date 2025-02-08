using AcessControlQR.Domain.Models;


namespace AcessControlQR.Application.Interfaces;

public interface IAccessRecordRepository
{
    Task<AccessRecord> GetByIdAsync(int id);
    Task<IEnumerable<AccessRecord>> GetAllAsync();
    Task AddAsync(AccessRecord accessRecord);
    Task<IEnumerable<AccessRecord>> GetByVisitorIdAsync(int visitorId);
}