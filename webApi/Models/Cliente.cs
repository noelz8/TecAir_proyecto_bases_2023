using Microsoft.AspNetCore.Mvc;
using System;



public class Cliente
{

    public int ClienteID { get; set; }
    public required string NombreCompleto { get; set; }
    public int Telefono { get; set; }
    public required string Correo { get; set; }
    public bool EsEstudiante { get; set; }
    public required string Universidad { get; set; }
    public int Carnet { get; set; }
    // Otras propiedades según sea necesario

}