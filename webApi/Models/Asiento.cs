using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable
public class Asiento
{
    [Key]
    public int AvionAsientoId { get; set; }
    public int NumeroAsiento { get; set; }
    public bool Ocupado { get; set; }

    // Explicitly map the foreign key relationship to the AvionId property in the Avion entity.
    [ForeignKey("Avion")]
    public int AvionId { get; set; }

    public required Avion Avion { get; set; }
}