using System;
using System.Collections.Generic;

namespace AcessControlQR.Domain.Models;

public partial class AccessRecord
{
    public int Id { get; set; }

    public int? VisitorId { get; set; }

    public int? UserId { get; set; }

    public DateTime? AccessTime { get; set; }

    public string AccessType { get; set; } = null!;

    public string Status { get; set; } = null!;

    public virtual User? User { get; set; }

    public virtual Visitor? Visitor { get; set; }
}
