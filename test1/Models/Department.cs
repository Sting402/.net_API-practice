using System;
using System.Collections.Generic;

namespace test1.Models;

public partial class Department
{
    public string DeptId { get; set; } = null!;

    public string? DeptName { get; set; }

    public string? DeptDesc { get; set; }

    public bool Active { get; set; }

    public virtual ICollection<Employee> EmployeeNds { get; } = new List<Employee>();

    public virtual ICollection<Employee> EmployeeOds { get; } = new List<Employee>();

    public virtual ICollection<MealOrder> MealOrders { get; } = new List<MealOrder>();

    public virtual ICollection<OrderHistory> OrderHistories { get; } = new List<OrderHistory>();

    public virtual ICollection<Role> Roles { get; } = new List<Role>();
}
