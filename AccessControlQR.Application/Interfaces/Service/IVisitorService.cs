using AcessControlQR.Domain.DTO;

namespace AcessControlQR.Application.Interfaces;

public interface IVisitorService
{
    //Consulta o QRCode e informa ele pro cliente
    public Task<RegisterVisitorResponseDTO> RegisterVisitor(RegisterVisitorDTO registerVisitor);
    // Método para pegar QRCODE do usuário
    // Metodo para dar update no Status do usuário
}