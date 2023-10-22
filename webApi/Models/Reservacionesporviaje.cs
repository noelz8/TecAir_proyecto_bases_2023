using System;
using System.Collections.Generic;

namespace webApi.Models;

public partial class Reservacionesporviaje
{
    public int Viajeid { get; set; }

    public int Reservacionid { get; set; }

    public int? Numerodeasiento { get; set; }

    public virtual Reservacion Reservacion { get; set; }

    public virtual Viaje Viaje { get; set; }
}
