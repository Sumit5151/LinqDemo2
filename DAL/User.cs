using System;
using System.Collections.Generic;

namespace LinqDemo2.DAL;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}
