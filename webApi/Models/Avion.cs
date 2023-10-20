using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace webApi.Models;
#nullable disable
public partial class Avion
{
    public int Avionid { get; set; }

    public string Codigoaeropuertodestino { get; set; }

    public string Codigoaeropuertoorigen { get; set; }

    public string Imagen { get; set; }

    public int? Capacidad { get; set; }

    public string Aerolinea { get; set; }

    public string Modelo { get; set; }

}
