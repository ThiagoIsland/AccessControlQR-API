using AcessControlQR.Domain.DTO;

namespace AcessControlQR.Application.Interfaces;

public interface IVisitorService
{
    public Task<RegisterVisitorResponseDTO> RegisterVisitor(RegisterVisitorDTO registerVisitor);
    // Metodo para dar update no Status do usuário
    // Passa o Nome do Usuário
    // Checa se ele existe
    // Pega ele pelo nome
    // Da um Update no Status
    // Retorna ok pro usuário
}