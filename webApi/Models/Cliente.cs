using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

public class Cliente
{
    [Key]
    public int ClienteID { get; set; } // Identifiacion del Cliente
    [Required]
    public required string NombreCompleto { get; set; } //Nombre Completo (cambiar)
    [Required]
    public int Telefono { get; set; } //Numero de telefono 
    [Required]
    public required string Correo { get; set; } // Correo Electronico
    [Required]
    public bool EsEstudiante { get; set; } //Verifica si es Estudiante o no
    public required string Universidad { get; set; } //Nombre de la Universidad si es Estudiante
    public int Carnet { get; set; }// Numero de Carnet si es estudiante
}