using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;


public class Vuelo
{
    [Key]
    public int VueloId { get; set; } //El id del vuelo
    public int AvionId { get; set; } // ID del Avión
    public int OrigenId { get; set; } //ID del origen
    public int DestinoId { get; set; } //ID del destino


    // Se realiza un enlace con las demas tablas: Avion.cs, Origen.cs, Destino.cs
    public virtual required Avion Avion { get; set; }
    public virtual required Origen Origen { get; set; }
    public virtual required Destino Destino { get; set; }
}