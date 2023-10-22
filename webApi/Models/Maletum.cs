using System;
using System.Collections.Generic;

namespace webApi.Models;

public partial class Maletum
{
    public int Numero { get; set; }

    public int? Reservacionid { get; set; }

    public int? Clienteid { get; set; }

    public string Color { get; set; }

    public decimal Peso { get; set; }

}
