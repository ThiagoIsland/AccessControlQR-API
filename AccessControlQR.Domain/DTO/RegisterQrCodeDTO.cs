namespace AcessControlQR.Domain.DTO;

public class RegisterQrCodeDTO
{

    public int UserId { get; set; } 

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;
}