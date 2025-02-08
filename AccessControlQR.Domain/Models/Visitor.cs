using System;
using System.Collections.Generic;

namespace AcessControlQR.Domain.Models;

public partial class Visitor
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public string QRCode { get; set; } = null!;
    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<AccessRecord> AccessRecords { get; set; } = new List<AccessRecord>();
    
    public string GetQRCode()
    {
        return QRCode;
    }
    
    public void SetQRCode(string qrCode)
    {
        if (string.IsNullOrEmpty(qrCode))
        {
            throw new ArgumentException("QRCode cannot be empty.");
        }

        QRCode = qrCode;
    }

}
