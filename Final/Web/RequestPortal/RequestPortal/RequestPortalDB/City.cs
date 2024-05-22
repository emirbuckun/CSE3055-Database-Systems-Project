using System;
using System.Collections.Generic;

namespace RequestPortal.RequestPortalDB;

public partial class City
{
    public int CityId { get; set; }

    public string? CityName { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
