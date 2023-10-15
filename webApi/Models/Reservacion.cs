using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Reservacion
{
    [Key]
    public int ReservacionID { get; set; } //ID de Reservacion
    public int ClienteID { get; set; } // Id del Cliente que reservó
    public DateTime Fecha { get; set; } // Se obtiene la fecha de Reservacion
    public TimeSpan HoraInicio { get; set; } // Hora de salida del Vuelo
    public TimeSpan HoraFin { get; set; } // Hora de llegada del Vuelo
    public int CantidadPersonas { get; set; }//Cantidad de personas que reservaron
    public required string Descripcion { get; set; } // Descripción de la Reservacion
    public required IList<Maleta> Maletas { get; set; }// Cantidad de Maletas para calcular el precio
    public decimal Precio { get; private set; } //Precio unitario
    public decimal PrecioDerivado { get; set; } // Precio Total de la Reservacion

    [ForeignKey("ClienteID")] 
    public required Cliente Cliente { get; set; } 
    public static decimal CalcularCargoEquipaje(int cantidadMaletas)
    {
        // El pasajero tiene derecho a una única maleta sin costo
        decimal cargo = 0;
        // Si el pasajero tiene más de una maleta, se cobra 50$ adicionales por la segunda maleta
        if (cantidadMaletas > 1)
        {
            cargo += 50;
        }
        // Si el pasajero tiene más de tres maletas, se cobra una tarifa fija de 75$ adicionales por cada maleta adicional
        if (cantidadMaletas > 3)
        {
            cargo += (cantidadMaletas - 3) * 75;
        }
        return cargo;
    }


    public decimal CalcularCargoTotal()
    {
        // Calcular el cargo por equipaje
        var cargoEquipaje = CalcularCargoEquipaje(this.Maletas.Count);

        // Devolver el cargo total
        return this.Precio + cargoEquipaje;
    }

    // Obtiene el precio total con la cantidad de Maletas
    public void CalcularPrecioDerivado()
    {
        this.PrecioDerivado = CalcularCargoTotal();
    }
}