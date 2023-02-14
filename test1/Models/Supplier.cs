using System;
using System.Collections.Generic;

namespace test1.Models;

public partial class Supplier
{
    public string SupplierId { get; set; } = null!;

    public string SupplierName { get; set; } = null!;

    public string MealType { get; set; } = null!;

    public string? ContactPerson { get; set; }

    public string? Telephone { get; set; }

    public string Email { get; set; } = null!;

    public string? Address { get; set; }

    public string? Password { get; set; }

    public string? Jwt { get; set; }

    public string? Menu { get; set; }

    public bool Active { get; set; }

    public string? SupplierDesc { get; set; }
}
