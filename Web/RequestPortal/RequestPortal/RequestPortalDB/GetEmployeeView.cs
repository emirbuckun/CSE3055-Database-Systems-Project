using System;
using System.Collections.Generic;

namespace RequestPortal.RequestPortalDB;

public partial class GetEmployeeView
{
    public int Ssn { get; set; }

    public string? FullName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Mail { get; set; }

    public string? ManagerName { get; set; }

    public string? UserName { get; set; }

    public string? UserPassword { get; set; }

    public string? CityName { get; set; }

    public string? CompanyName { get; set; }

    public string? DepartmentName { get; set; }
}
