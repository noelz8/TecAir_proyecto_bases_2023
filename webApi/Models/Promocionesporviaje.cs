using System;
using System.Collections.Generic;

namespace webApi.Models;

public partial class Promocionesporviaje
{
    public int Viajeid { get; set; }

    public int Promocionid { get; set; }

    public DateOnly Periodo { get; set; }

}
