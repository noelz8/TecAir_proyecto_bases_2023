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

}
