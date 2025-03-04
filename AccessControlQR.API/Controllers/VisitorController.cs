using AcessControlQR.Application.Interfaces;
using AcessControlQR.Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AccessControlQR.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VisitorController : ControllerBase
{
    private readonly IVisitorService _visitorService;
    private readonly IQrCodeService _codeService;

    public VisitorController(IVisitorService visitorService, IQrCodeService codeService) 
    {
        _visitorService = visitorService;
        _codeService = codeService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterVisitor([FromBody] RegisterVisitorDTO registerVisitorDto)
    {
        var success = await _visitorService.RegisterVisitor(registerVisitorDto);
        
        return Ok(new { message = "User sucessfully registered." });
    }

    
    [HttpPost("generate")]
    public async Task<IActionResult> GenerateQr([FromBody] RegisterQrCodeDTO registerQrCodeDto)
    {
        var success = await _codeService.GenerateQrCode(registerQrCodeDto);
        
        return Ok(new { message = "QRCode sucessfully generated." });
    }

    [HttpGet("validate")]
    public async Task<IActionResult> ValidateQr(string scannedQrCode, int id)
    {
        var validate = await _codeService.ValidatedQrCode(scannedQrCode, id);

        return Ok(validate);
    }

    [HttpGet("get")]
    public async Task<IActionResult> GetQr(string name)
    {
        var QrCode = await _codeService.GetQrCode(name);

        return Ok(QrCode);
    }

}