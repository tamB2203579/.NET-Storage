﻿using System;
using System.Collections.Generic;

namespace Exercise3.Data;

public partial class Gender
{
    public int GenderId { get; set; }

    public string GenderName { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
