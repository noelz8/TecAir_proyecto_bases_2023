using Microsoft.AspNetCore.Mvc;
using System;

public class Cliente
{

    public int ClienteID { get; set; } // Identifiacion del Cliente
    public required string NombreCompleto { get; set; } //Nombre Completo (cambiar)
    public int Telefono { get; set; } //Numero de telefono 
    public required string Correo { get; set; } // Correo Electronico
    public bool EsEstudiante { get; set; } //Verifica si es Estudiante o no
    public required string Universidad { get; set; } //Nombre de la Universidad si es Estudiante
    public int Carnet { get; set; }// Numero de Carnet si es estudiante
}