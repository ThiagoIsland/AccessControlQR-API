using AcessControlQR.Domain.DTO;

namespace AcessControlQR.Application.Interfaces;

public interface IVisitorService
{
    public Task<RegisterVisitorResponseDTO> RegisterVisitor(RegisterVisitorDTO registerVisitor);
    // Metodo para dar update no Status do usuário
}