using AcessControlQR.Application.Interfaces;

namespace AcessControlQR.Application.Services;

public class AccessControlService : IAccessControlService
{
    private readonly IAccessRecordRepository _logRepository;
    public AccessControlService(IAccessRecordRepository logRepository)
    {
        _logRepository = logRepository;
    }
    
    
    //Registra o ACESSO do Visitante
    //Pegando: IDUser, IDVisitante, AccessTime, AccessType(Entrance or Exit), Status
    //Fazer isso ser chamado num método chamando o método de validar QRCode do IQrCodeService
}