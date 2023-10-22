using System;
using System.Collections.Generic;

namespace webApi.Models;

public partial class Asiento
{
    public int Asientoid { get; set; }

    public int? Avionid { get; set; }

    public string Posicionasiento { get; set; }

    public string Estado { get; set; }

}
