using System;
using System.Collections.Generic;

namespace Exercise1.Models;

public partial class Dvd
{
    public int DvdcodeNo { get; set; }

    public string Dvdtitle { get; set; } = null!;

    public string Language { get; set; } = null!;

    public bool SubTitle { get; set; }

    public decimal Price { get; set; }
}
