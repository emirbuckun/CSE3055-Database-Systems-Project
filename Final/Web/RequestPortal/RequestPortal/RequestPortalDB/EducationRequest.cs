using System;
using System.Collections.Generic;

namespace RequestPortal.RequestPortalDB;

public partial class EducationRequest
{
    public int RequestId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? EducationName { get; set; }

    public virtual Request Request { get; set; } = null!;
}
