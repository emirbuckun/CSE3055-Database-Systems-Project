using System;
using System.Collections.Generic;

namespace RequestPortal.RequestPortalDB;

public partial class GetTravelRequestView
{
    public int RequestId { get; set; }

    public byte? RequestType { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? Explanation { get; set; }

    public int? EmployeeSsn { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Origin { get; set; }

    public string? Destination { get; set; }
}
