using System.ComponentModel.DataAnnotations;

namespace AcessControlQR.Domain.DTO;

public class RegisterVisitorDTO
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    public string Phone { get; set; }
    
    public string Status { get; set; }
}