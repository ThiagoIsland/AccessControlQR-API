namespace AcessControlQR.Application.Interfaces;

public interface IAccessControlService
{

    Task<string> RecordAccess(int IDVisitor, string accessType, string user);

}