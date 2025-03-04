using AcessControlQR.Domain.Models;

namespace AcessControlQR.Domain.DTO;

public class QrCodeResponseDTO
{
    public string Message { get; set; }
    public string QrCode { get; set; }
}