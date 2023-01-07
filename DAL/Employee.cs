using System;
using System.Collections.Generic;

namespace LinqDemo2.dal;

public partial class Employee
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Gender { get; set; }

    public int? Salary { get; set; }

    public string? City { get; set; }

    public int? DepartmentId { get; set; }

    public virtual Department? Department { get; set; }
}
