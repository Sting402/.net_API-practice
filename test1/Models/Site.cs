using System;
using System.Collections.Generic;

namespace test1.Models;

public partial class Site
{
    public string SiteId { get; set; } = null!;

    public string SiteName { get; set; } = null!;

    public string ZipCode { get; set; } = null!;

    public string SiteAddress { get; set; } = null!;

    public bool Active { get; set; }

    public string? SiteDesc { get; set; }

    public virtual ICollection<Permission> Permissions { get; } = new List<Permission>();
}
