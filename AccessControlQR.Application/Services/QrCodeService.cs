using AcessControlQR.Application.Interfaces;
using AcessControlQR.Domain.Models;
using AcessControlQR.Domain.DTO;

namespace AcessControlQR.Application.Services;

public class QrCodeService : IQrCodeService
{
    private readonly IQrCodeRepository _qrCodeRepository;
    public QrCodeService(IQrCodeRepository qrCodeRepository, IVisitorRepository visitorRepository)
    {
        _qrCodeRepository = qrCodeRepository;
    }
    
    public async Task<RegisterQrCodeRespondeDTO> GenerateQrCode(RegisterQrCodeDTO registerQrCodeDto)
    {
        var existingName = _qrCodeRepository.GetVisitorByName(registerQrCodeDto.Name);
        if (existingName == null) 
            throw new Exception("Visitor not recognized or doesn't exist");
        
        var existingEmail = _qrCodeRepository.GetVisitorByEmail(registerQrCodeDto.Email);
        if (existingEmail == null) 
            throw new Exception("Visitor not recognized or doesn't exist");

        var userId = await _qrCodeRepository.GetIdUser(registerQrCodeDto.UserId);
        
        string content = $"{userId}-{registerQrCodeDto.Email}-{Guid.NewGuid()}";
        
        VisitorsQrCode visitorQrCode = new VisitorsQrCode
        {
            Name = registerQrCodeDto.Name,
            Email = registerQrCodeDto.Email,
            QrCode = content,
            CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified),
            UpdatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified)
        };

         await _qrCodeRepository.AddAsync(visitorQrCode);
        
         return new RegisterQrCodeRespondeDTO
         {
             Message = "QRCode sucessfully generated"
         };    
    }
 
}

   