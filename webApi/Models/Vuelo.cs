using System;
using System.Collections.Generic;

namespace webApi.Models;

public partial class Vuelo
{
    public int Vueloid { get; set; }

    public string Codigoaeropuertoorigen { get; set; }

    public string Codigoaeropuertodestino { get; set; }

    public string Origen { get; set; }

    public string Destino { get; set; }

    public int? Viajeid { get; set; }

    public int? Avionid { get; set; }


}
