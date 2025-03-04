using AcessControlQR.Domain.Models;


namespace AcessControlQR.Application.Interfaces;

public interface IAccessRecordRepository
{
    Task<string> GetStatus(int IDVisitor);
    Task<int> GetUserID(string name);
    Task AddAsync(AccessRecord accessRecord);
    Task<IEnumerable<AccessRecord>> GetByVisitorIdAsync(int visitorId);
}