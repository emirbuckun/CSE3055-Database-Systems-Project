﻿using System;
using System.Collections.Generic;

namespace RequestPortal.RequestPortalDB;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string? DepartmentName { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
