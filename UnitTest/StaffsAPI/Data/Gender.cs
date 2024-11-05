using System;
using System.Collections.Generic;

namespace StaffsAPI.Data;

public partial class Gender
{
    public int GenId { get; set; }

    public string GenName { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
