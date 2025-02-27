namespace AcessControlQR.Domain.Models;

public class VisitorsQrCode
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? QrCode { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
