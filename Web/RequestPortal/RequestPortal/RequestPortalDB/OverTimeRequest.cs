using System;
using System.Collections.Generic;

namespace RequestPortal.RequestPortalDB;

public partial class OverTimeRequest
{
    public int RequestId { get; set; }

    public DateTime? Date { get; set; }

    public int? Hours { get; set; }

    public virtual Request Request { get; set; } = null!;
}
