using System;
using System.Collections.Generic;

namespace test1.Models;

public partial class User
{
    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Usertype { get; set; } = null!;

    public string? Token { get; set; }

    public string? UserDesc { get; set; }
}
