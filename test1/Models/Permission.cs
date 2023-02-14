using System;
using System.Collections.Generic;

namespace test1.Models;

public partial class Permission
{
    public string PermissionId { get; set; } = null!;

    public string WokerId { get; set; } = null!;

    public string RoleId { get; set; } = null!;

    public string SiteId { get; set; } = null!;

    public string? PermissionDesc { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual Site Site { get; set; } = null!;

    public virtual Employee Woker { get; set; } = null!;
}
