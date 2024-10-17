using System;
using System.Collections.Generic;

namespace Exercise2.Models;

public partial class Canbo
{
    public int MaCb { get; set; }

    public string TenCb { get; set; } = null!;

    public int? ChucVuCb { get; set; }

    public int SoGioGiang { get; set; }

    public decimal DonGia { get; set; }

    public virtual Chucvu? ChucVuCbNavigation { get; set; }
}
