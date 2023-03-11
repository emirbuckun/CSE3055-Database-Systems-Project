using System;
using System.Collections.Generic;

namespace RequestPortal.RequestPortalDB;

public partial class Request
{
    public int RequestId { get; set; }

    public byte? RequestType { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? Explanation { get; set; }

    public int? EmployeeSsn { get; set; }

    public virtual AdvanceRequest? AdvanceRequest { get; set; }

    public virtual EducationRequest? EducationRequest { get; set; }

    public virtual LeaveRequest? LeaveRequest { get; set; }

    public virtual OverTimeRequest? OverTimeRequest { get; set; }

    public virtual ICollection<RequestFlow> RequestFlows { get; } = new List<RequestFlow>();

    public virtual TravelRequest? TravelRequest { get; set; }
}
