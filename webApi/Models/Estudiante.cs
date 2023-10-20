using System;
using System.Collections.Generic;

namespace webApi.Models;

public partial class Estudiante
{
    public int Carnet { get; set; }

    public int? Clienteid { get; set; }

    public virtual Cliente Cliente { get; set; }

    public virtual ICollection<Universidad> Universidads { get; set; } = new List<Universidad>();
}
