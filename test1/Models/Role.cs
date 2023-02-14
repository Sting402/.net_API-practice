using System;
using System.Collections.Generic;

namespace test1.Models;

public partial class Role
{
    public string RoleId { get; set; } = null!;

    public string? RoleName { get; set; }

    public string? DeptId { get; set; }

    public bool Active { get; set; }

    public string? RoleDesc { get; set; }

    public virtual Department? Dept { get; set; }

    public virtual ICollection<MealOrder> MealOrders { get; } = new List<MealOrder>();

    public virtual ICollection<OrderHistory> OrderHistories { get; } = new List<OrderHistory>();

    public virtual ICollection<Permission> Permissions { get; } = new List<Permission>();
}
