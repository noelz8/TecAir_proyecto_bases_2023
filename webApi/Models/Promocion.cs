using System;
using System.Collections.Generic;

namespace webApi.Models;

public partial class Promocion
{
    public int Promocionid { get; set; }

    public string Origen { get; set; }

    public string Destino { get; set; }

    public virtual ICollection<Viaje> Viajes { get; set; } = new List<Viaje>();
}
