using AcessControlQR.Domain.DTO;
using AcessControlQR.Domain.Models;

namespace AcessControlQR.Application.Interfaces;

public interface IQrCodeService
{

    public Task<RegisterQrCodeRespondeDTO> GenerateQrCode(RegisterQrCodeDTO registerQrCodeDto);
    
    // Pegar o CPF
    // - Passa o CPF pro sistema
    // - ⁠verifica se é nulo
    // - ⁠localiza na tabela 
    // - ⁠trás o código QRcode 
    // - ⁠desconverte de base64 
    // - ⁠gera uma imagem QRCode baseada naquilo
    // - ⁠exibe pro usuário no front end

}