using System;
using System.Collections.Generic;

namespace Web_Pro.Entities;

public partial class Tinh
{
    public int MaT { get; set; }

    public string? Ten { get; set; }

    public string? Cap { get; set; }

    public virtual ICollection<Huyen> Huyens { get; set; } = new List<Huyen>();

    public virtual ICollection<Xa> Xas { get; set; } = new List<Xa>();
}
