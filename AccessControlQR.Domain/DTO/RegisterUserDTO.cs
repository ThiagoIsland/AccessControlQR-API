using System.ComponentModel.DataAnnotations;

namespace AcessControlQR.Domain.DTO;

public class RegisterUserDTO
{
    [Required]
    public string Username { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }
    
    [Required]
    public string Role { get; set; }
}