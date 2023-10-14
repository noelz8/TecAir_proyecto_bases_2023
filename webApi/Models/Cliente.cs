using Microsoft.AspNetCore.Mvc;
using System;

public class Cliente
{
    public int ClienteID { get; set; }
    public string NombreCompleto { get; set; }
    public int Telefono { get; set; }
    public string Correo { get; set; }
    public bool EsEstudiante { get; set; }
    public string Universidad { get; set; }
    public int Carnet { get; set; }
    // Otras propiedades según sea necesario

    public Cliente(){
        NombreCompleto = string.Empty;
        Universidad = string.Empty;
        Correo = string.Empty;
    }
}