using System;
using System.Collections.Generic;

namespace RequestPortal.RequestPortalDB;

public partial class Company
{
    public int CompanyId { get; set; }

    public string? CompanyName { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
