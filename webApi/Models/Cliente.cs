using System;
using System.Collections.Generic;

namespace webApi.Models;

public partial class Cliente
{
    public int Clienteid { get; set; }

    public string Nombre { get; set; }

    public string Apellido1 { get; set; }

    public string Apellido2 { get; set; }

    public string Telefono { get; set; }

    public string Correo { get; set; }

    public virtual ICollection<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();

    public virtual ICollection<Reservacion> Reservacions { get; set; } = new List<Reservacion>();
}
