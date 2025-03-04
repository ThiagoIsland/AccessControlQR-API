using AcessControlQR.Application.Interfaces;
using AcessControlQR.Domain.Models;
using System.ComponentModel;

namespace AcessControlQR.Application.Services;

public class AccessControlService : IAccessControlService
{
    private readonly IAccessRecordRepository _logRepository;
    public AccessControlService(IAccessRecordRepository logRepository)
    {
        _logRepository = logRepository;
    }
    
    public async Task<string> RecordAccess(int IDVisitor, string accessType, string user)
    {
        var userId = await _logRepository.GetUserID(user);
        if (userId == null)
            throw new Exception("User not recognized or doesn't exist");

        var visitorId = await _logRepository.GetStatus(IDVisitor);
        if (visitorId == null)
            throw new Exception("Visitor not recognized or doesn't exist");

        AccessRecord accessRecord = new AccessRecord
        {
            VisitorId = IDVisitor,
            UserId = userId,
            AccessTime = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified),
            AccessType = accessType,
            Status = visitorId, 
        };

        await _logRepository.AddAsync(accessRecord);

        return "Ok";
    }
}