using AcessControlQR.Domain.DTO;
using AcessControlQR.Domain.Models;

namespace AcessControlQR.Application.Interfaces;

public interface IQrCodeService
{

    public Task<RegisterQrCodeRespondeDTO> GenerateQrCode(RegisterQrCodeDTO registerQrCodeDto);
    public Task<object> GetQrCode(string name);
    public Task<QrCodeResponseDTO> ValidatedQrCode(string scannedQrCode, int id);


}