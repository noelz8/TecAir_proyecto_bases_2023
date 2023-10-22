using System;
using System.Collections.Generic;

namespace webApi.Models;

public partial class Viaje
{
    public int Viajeid { get; set; }

    public DateTime Horario { get; set; }

    public decimal Precio { get; set; }

    public string Estado { get; set; }

    public DateOnly Fecha { get; set; }

}
