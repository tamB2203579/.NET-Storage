using System;
using System.Collections.Generic;

namespace Exercise3.Models;

public partial class Khachhang
{
    public int SoHd { get; set; }

    public string TenKh { get; set; } = null!;

    public string SoCmnd { get; set; } = null!;

    public decimal SoTien { get; set; }

    public DateTime NgayTt { get; set; }

    public int? Phong { get; set; }

    public virtual Phong? PhongNavigation { get; set; }
}
