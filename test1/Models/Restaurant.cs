using System;
using System.Collections.Generic;

namespace test1.Models;

public partial class Restaurant
{
    public string RestId { get; set; } = null!;

    public string RestName { get; set; } = null!;

    public string SiteId { get; set; } = null!;

    public bool Active { get; set; }

    public string? RestDesc { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();

    public virtual ICollection<MealOrder> MealOrders { get; } = new List<MealOrder>();

    public virtual ICollection<OrderHistory> OrderHistories { get; } = new List<OrderHistory>();
}
