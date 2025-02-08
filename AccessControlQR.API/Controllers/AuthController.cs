using AcessControlQR.Application.Interfaces;
using AcessControlQR.Domain.DTO;
using AcessControlQR.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly BaseContext _context;

    public AuthController(IAuthService authService, BaseContext baseContext)
    {
        _authService = authService;
        _context = baseContext;
    }
    
    
    [HttpGet("teste")]
    public IActionResult GetBancoTest()
    {
        var test = _context.Database.CanConnect();
        return Content($"Conexão com o banco: {test}");
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var token = await _authService.AuthenticateAsync(loginDto.Username, loginDto.Password);
        if (token == null)
            return Unauthorized(new { message = "Usuário ou senha inválidos." });
        
        return Ok(new { token });
    }
}