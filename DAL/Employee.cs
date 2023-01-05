using System;
using System.Collections.Generic;

namespace LinqDemo2.DAL;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int DepartmentId { get; set; }

    public string Email { get; set; } = null!;

    public int? Salary { get; set; }

    public virtual Department Department { get; set; } = null!;
}
