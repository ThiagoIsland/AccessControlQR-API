using AcessControlQR.Application.Interfaces;
using AcessControlQR.Domain.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AccessControlQR.API.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class VisitorController : ControllerBase
{
    private readonly IVisitorService _visitorService;
    private readonly IQrCodeService _codeService;
    private readonly IAccessControlService _recordservice;

    public VisitorController(IVisitorService visitorService, IQrCodeService codeService, IAccessControlService recordService) 
    {
        _visitorService = visitorService;
        _codeService = codeService;
        _recordservice = recordService;
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
    [HttpGet("validateAccess")]
    public async Task<IActionResult> ValidateQr(string scannedQrCode, int idVisitor, string user, string accessType)
    {
        var validate = await _codeService.ValidatedQrCode(scannedQrCode, idVisitor);
        var record = await _recordservice.RecordAccess(idVisitor, accessType, user);

        return Ok(validate);
    }
    [HttpGet("get")]
    public async Task<IActionResult> GetQr(string name)
    {
        var QrCode = await _codeService.GetQrCode(name);

        return Ok(QrCode);
    }

}