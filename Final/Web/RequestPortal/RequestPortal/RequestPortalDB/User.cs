using System;
using System.Collections.Generic;

namespace RequestPortal.RequestPortalDB;

public partial class User
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? UserPassword { get; set; }

    public DateTime? CreateDate { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();

    public virtual ICollection<UserRole> UserRoles { get; } = new List<UserRole>();
}
