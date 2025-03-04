using AcessControlQR.Domain.DTO;
using AcessControlQR.Domain.Models;

namespace AcessControlQR.Application.Interfaces;

public interface IQrCodeService
{

    public Task<RegisterQrCodeRespondeDTO> GenerateQrCode(RegisterQrCodeDTO registerQrCodeDto);
    public Task<string> GetQrCode(string name);
    public Task<string> ValidatedQrCode(string scannedQrCode, int id);


}