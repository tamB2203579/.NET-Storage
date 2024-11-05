using System;
using System.Collections.Generic;

namespace StaffsAPI.Data;

public partial class Department
{
    public int DepId { get; set; }

    public string DepName { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
