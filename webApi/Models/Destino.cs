using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

public class Destino
{
    [Key]
    public int DestinoId { get; set; }
    public required string Ciudad { get; set; }
    public required string Pais { get; set; }
    public required string CodigoAeropuerto { get; set; }

    public virtual required ICollection<Vuelo> Vuelos { get; set; }
}