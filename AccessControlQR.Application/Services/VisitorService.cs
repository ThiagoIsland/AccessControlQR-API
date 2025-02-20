using AcessControlQR.Application.Interfaces;
using AcessControlQR.Domain.DTO;
using AcessControlQR.Domain.Models;

namespace AcessControlQR.Application.Services;

public class VisitorService : IVisitorService
{
    private readonly IVisitorRepository _repository;
    private readonly IQRCodeService _qrCodeService;

    public VisitorService(IVisitorRepository repository, IQRCodeService qrCodeService)
    {
        _repository = repository;
    }

    public async Task<RegisterVisitorResponseDTO> RegisterVisitor(RegisterVisitorDTO registerVisitor)
    {
        var existingVisitor = await _repository.GetByEmailAsync(registerVisitor.Email);
        if (existingVisitor != null && existingVisitor.Email == registerVisitor.Email)
            throw new Exception("Visitante já cadastrado.");


        Visitor visitor = new Visitor
        {
            Name = registerVisitor.Name,
            Email = registerVisitor.Email,
            Phone = registerVisitor.Phone,
            Status = registerVisitor.Status,
            CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified),
            UpdatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified)
        };
        
        await _repository.AddAsync(visitor);
        
        return new RegisterVisitorResponseDTO
        {
            Message = "Visitante cadastrado com sucesso.",
            VisitorId = visitor.Id,
        };
    }

}