using System;
using System.Collections.Generic;

namespace webApi.Models;

public partial class Estudiante
{
    public string Carnet { get; set; }

    public int? Clienteid { get; set; }

    public int Cantidaddeviajes { get; set; }

    public int? Millas { get; set; }

}
