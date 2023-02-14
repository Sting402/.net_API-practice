using System;
using System.Collections.Generic;

namespace test1.Models;

public partial class Employee
{
    public string WorkerId { get; set; } = null!;

    public string EName { get; set; } = null!;

    public string CName { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string OdId { get; set; } = null!;

    public string? NdId { get; set; }

    public string Shift { get; set; } = null!;

    public string? Email { get; set; }

    public string PrExcel { get; set; } = null!;

    public string? DefaultMealOrder { get; set; }

    public string? DefaultMealType { get; set; }

    public string? DefaultRest { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? ModifyDate { get; set; }

    public bool Active { get; set; }

    public string Password { get; set; } = null!;

    public string? Jwt { get; set; }

    public string? Menu { get; set; }

    public string? WorkerDesc { get; set; }

    public virtual Restaurant? DefaultRestNavigation { get; set; }

    public virtual ICollection<MealOrder> MealOrders { get; } = new List<MealOrder>();

    public virtual Department? Nd { get; set; }

    public virtual Department Od { get; set; } = null!;

    public virtual ICollection<OrderHistory> OrderHistories { get; } = new List<OrderHistory>();

    public virtual ICollection<Permission> Permissions { get; } = new List<Permission>();
}
