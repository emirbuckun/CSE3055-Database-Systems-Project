using System;
using System.Collections.Generic;

namespace RequestPortal.RequestPortalDB;

public partial class TravelRequest
{
    public int RequestId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Origin { get; set; }

    public string? Destination { get; set; }

    public virtual Request Request { get; set; } = null!;
}
