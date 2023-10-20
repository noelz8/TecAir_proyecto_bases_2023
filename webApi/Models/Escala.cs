using System;
using System.Collections.Generic;

namespace webApi.Models;

public partial class Escala
{
    public string Codigoaeropuertoescala { get; set; }

    public int Avionid { get; set; }

    public string Vueloorigen { get; set; }

    public string Pais { get; set; }

    public string Ciudad { get; set; }

    public virtual Avion Avion { get; set; }
}
