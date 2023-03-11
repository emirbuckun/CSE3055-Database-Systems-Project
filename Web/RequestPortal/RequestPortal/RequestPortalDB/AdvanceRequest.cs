using System;
using System.Collections.Generic;

namespace RequestPortal.RequestPortalDB;

public partial class AdvanceRequest
{
    public int RequestId { get; set; }

    public decimal? RequestedAmount { get; set; }

    public decimal? ApprovedAmount { get; set; }

    public virtual Request Request { get; set; } = null!;
}
