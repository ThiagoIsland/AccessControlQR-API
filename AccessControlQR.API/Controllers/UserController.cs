using AcessControlQR.Application.Interfaces;
using AcessControlQR.Application.Services;
using AcessControlQR.Domain.DTO;
using AcessControlQR.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace AccessControlQR.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly BaseContext _context;
    
    public UserController(IUserService userService, BaseContext baseContext)
    {
        _userService = userService;
        _context = baseContext;
    }
    
    [HttpGet("test")]
    public IActionResult GetBancoTest()
    {
        var test = _context.Database.CanConnect();
        return Content($"Database connection: {test}");
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserDTO registerUserDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        bool success = await _userService.RegisterUserAsync(registerUserDto);
        if (!success)
            return BadRequest(new { message = "User already exist" });

        return Ok(new { message = "User sucessfully registered." });
    }
}