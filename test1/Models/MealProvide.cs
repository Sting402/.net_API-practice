using System;
using System.Collections.Generic;

namespace test1.Models;

public partial class MealProvide
{
    public string MpId { get; set; } = null!;

    public string SiteId { get; set; } = null!;

    public string SupplierId { get; set; } = null!;

    public string MealOrder { get; set; } = null!;

    public string MealType { get; set; } = null!;

    public string Year { get; set; } = null!;

    public string Month { get; set; } = null!;

    public string? MpDesc { get; set; }
}
