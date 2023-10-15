using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

public class Maleta
{
    public int NumeroMaleta { get; set; }// ID de la Maleta
    public int Peso { get; set; } // Peso de la maleta en kg
    public int ReservacionID { get; set; }//Id de la Reservacion a la que pertence
    public required string Dueno { get; set; } // Dueño de la maleta
    public required string Color { get; set; } // Dueño de la maleta
    public decimal Precio { get; set; } //Precio de la maleta
}
