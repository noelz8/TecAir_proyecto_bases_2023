using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

public class Origen
{
    [Key]
    public int OrigenId { get; set; }
    public required string Ciudad { get; set; }
    public required string Pais { get; set; }
    public required string CodigoAeropuerto { get; set; }

    public virtual required ICollection<Vuelo> Vuelos { get; set; }
}