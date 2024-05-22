using System;
using System.Collections.Generic;

namespace RequestPortal.RequestPortalDB;

public partial class RequestFlow
{
    public int RequestFlowId { get; set; }

    public int? RequestId { get; set; }

    public int? ApproverSsn { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? CloseDate { get; set; }

    public byte? Status { get; set; }

    public string? Explanation { get; set; }

    public virtual Employee? ApproverSsnNavigation { get; set; }

    public virtual Request? Request { get; set; }
}
