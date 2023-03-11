using System;
using System.Collections.Generic;

namespace RequestPortal.RequestPortalDB;

public partial class GetUserRoleView
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? UserPassword { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? Role { get; set; }
}
