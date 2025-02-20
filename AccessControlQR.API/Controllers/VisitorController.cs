using AcessControlQR.Application.Interfaces;
using AcessControlQR.Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AccessControlQR.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VisitorController : ControllerBase
{
    private readonly IVisitorService _visitorService;

    public VisitorController(IVisitorService visitorService) 
    {
        _visitorService = visitorService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterVisitor([FromBody] RegisterVisitorDTO registerVisitorDto)
    {
        var success = await _visitorService.RegisterVisitor(registerVisitorDto);
        
        return Ok(new { message = "Usuário cadastrado com sucesso." });
    }

}