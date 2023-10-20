using System;
using System.Collections.Generic;

namespace webApi.Models;

public partial class Viaje
{
    public int Viajeid { get; set; }

    public DateOnly? Fecha { get; set; }

    public TimeOnly? Horario { get; set; }

    public decimal? Precio { get; set; }

    public int? Numeroasiento { get; set; }

    public int? Reservacionid { get; set; }

    public int? Avionid { get; set; }

    public virtual Avion Avion { get; set; }

    public virtual Reservacion Reservacion { get; set; }

    public virtual ICollection<Promocion> Promocions { get; set; } = new List<Promocion>();
}
