﻿using System;
using System.Collections.Generic;

namespace webApi.Models;

public partial class Destino
{
    public string Codigoaeropuertodestino { get; set; }

    public string Ciudad { get; set; }

    public string Pais { get; set; }

    public string Puertaingreso { get; set; }

    public TimeOnly? Horallegada { get; set; }

    public virtual ICollection<Avion> Avions { get; set; } = new List<Avion>();
}
