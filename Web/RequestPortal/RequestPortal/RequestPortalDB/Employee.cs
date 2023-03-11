using System;
using System.Collections.Generic;

namespace RequestPortal.RequestPortalDB;

public partial class Employee
{
    public int Ssn { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Mail { get; set; }

    public int? ManagerSsn { get; set; }

    public int? UserId { get; set; }

    public int? CityId { get; set; }

    public int? DepartmentId { get; set; }

    public int? CompanyId { get; set; }

    public virtual City? City { get; set; }

    public virtual Company? Company { get; set; }

    public virtual Department? Department { get; set; }

    public virtual ICollection<Employee> InverseManagerSsnNavigation { get; } = new List<Employee>();

    public virtual Employee? ManagerSsnNavigation { get; set; }

    public virtual ICollection<RequestFlow> RequestFlows { get; } = new List<RequestFlow>();

    public virtual User? User { get; set; }
}
