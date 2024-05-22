using System;
using System.Collections.Generic;

namespace RequestPortal.RequestPortalDB;

public partial class GetRequestWithFlowView
{
    public int RequestId { get; set; }

    public byte? RequestType { get; set; }

    public int? EmployeeSsn { get; set; }

    public DateTime? RequestCreateDate { get; set; }

    public string? RequestExplanation { get; set; }

    public int RequestFlowId { get; set; }

    public int? ApproverSsn { get; set; }

    public DateTime? FlowCreateDate { get; set; }

    public DateTime? FlowCloseDate { get; set; }

    public string? FlowExplanation { get; set; }

    public byte? FlowStatus { get; set; }
}
