using System;
using System.Collections.Generic;

namespace webApi.Models;

public partial class Avion
{
    public int Avionid { get; set; }

    public string Codigoaeropuertodestino { get; set; }

    public string Codigoaeropuertoorigen { get; set; }

    public string Imagen { get; set; }

    public int? Capacidad { get; set; }

    public string Aerolinea { get; set; }

    public string Modelo { get; set; }

    public virtual Destino CodigoaeropuertodestinoNavigation { get; set; }

    public virtual Origen CodigoaeropuertoorigenNavigation { get; set; }

    public virtual ICollection<Viaje> Viajes { get; set; } = new List<Viaje>();
}
