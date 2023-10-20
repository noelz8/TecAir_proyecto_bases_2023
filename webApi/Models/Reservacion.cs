﻿using System;
using System.Collections.Generic;

namespace webApi.Models;

public partial class Reservacion
{
    public int Reservacionid { get; set; }

    public int? Cantidadmaletas { get; set; }

    public int? Año { get; set; }

    public int? Mes { get; set; }

    public int? Dia { get; set; }

    public int? Clienteid { get; set; }

    public virtual Cliente Cliente { get; set; }

}
