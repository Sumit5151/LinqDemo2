using System;
using System.Collections.Generic;

namespace LinqDemo2.DAL;

public partial class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
