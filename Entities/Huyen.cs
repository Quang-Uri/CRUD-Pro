using System;
using System.Collections.Generic;

namespace Web_Pro.Entities;

public partial class Huyen
{
    public int MaH { get; set; }

    public string? Ten { get; set; }

    public string? Cap { get; set; }

    public int? MaT { get; set; }

    public virtual Tinh? MaTNavigation { get; set; }

    public virtual ICollection<Xa> Xas { get; set; } = new List<Xa>();
}
