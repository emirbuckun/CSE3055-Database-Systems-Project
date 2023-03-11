﻿using System;
using System.Collections.Generic;

namespace RequestPortal.RequestPortalDB;

public partial class GetOverTimeRequestView
{
    public int RequestId { get; set; }

    public byte? RequestType { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? Explanation { get; set; }

    public int? EmployeeSsn { get; set; }

    public DateTime? Date { get; set; }

    public int? Hours { get; set; }
}
