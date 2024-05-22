using System;
using System.Collections.Generic;

namespace RequestPortal.RequestPortalDB;

public partial class GetLeaveRequestView
{
    public int RequestId { get; set; }

    public byte? RequestType { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? Explanation { get; set; }

    public int? EmployeeSsn { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? RequestReason { get; set; }

    public DateTime? TotalDay { get; set; }
}
