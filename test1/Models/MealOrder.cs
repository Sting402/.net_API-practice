using System;
using System.Collections.Generic;

namespace test1.Models;

public partial class MealOrder
{
    public string OrderId { get; set; } = null!;

    public string WorkerId { get; set; } = null!;

    public string RestId { get; set; } = null!;

    public DateTime OrderDate { get; set; }

    public string MealType { get; set; } = null!;

    public string MealOrder1 { get; set; } = null!;

    public int? MealNumber { get; set; }

    public string? RoleId { get; set; }

    public string? DeptId { get; set; }

    public bool Active { get; set; }

    public DateTime UpdateTime { get; set; }

    public string? OrderDesc { get; set; }

    public virtual Department? Dept { get; set; }

    public virtual Restaurant Rest { get; set; } = null!;

    public virtual Role? Role { get; set; }

    public virtual Employee Worker { get; set; } = null!;
}
