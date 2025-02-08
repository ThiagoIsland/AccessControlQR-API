using System.ComponentModel.DataAnnotations;

namespace AcessControlQR.Domain.DTO;

public class LoginDTO
{
    [Required]
    public string Username { get; set; }
    
    [Required]
    public string Password { get; set; }
}