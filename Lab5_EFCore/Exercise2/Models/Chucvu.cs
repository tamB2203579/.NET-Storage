using System;
using System.Collections.Generic;

namespace Exercise2.Models;

public partial class Chucvu
{
    public int MaCv { get; set; }

    public string? TenCv { get; set; }

    public virtual ICollection<Canbo> Canbos { get; set; } = new List<Canbo>();
}
