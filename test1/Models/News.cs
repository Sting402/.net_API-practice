using System;
using System.Collections.Generic;

namespace test1.Models;

public partial class News
{
    public string NewsId { get; set; } = null!;

    public string NewsTitle { get; set; } = null!;

    public string NewsContent { get; set; } = null!;

    public string NewsFileLink { get; set; } = null!;

    public bool IsVip { get; set; }
}
