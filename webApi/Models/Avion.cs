using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;


#nullable disable

public class Avion
{
    [Key]
    public int AvionId { get; set; }//El ID del avión

    
    public string Matricula { get; set; }// La matricula puede contener numeros y letras
    public string Modelo { get; set; } // El modelo del avion
    public string Fabricante { get; set; }// Fabricante del avión
    public int Capacidad { get; set; } // Capacidad total del avión
    public  string Imagen { get; set; } // string de donde se va meter la dirección de la imagen
    public ICollection<Asiento> Asientos { get; set; } //Entidad Asientos(Atributo Multivaluado)

    public virtual ICollection<Vuelo> Vuelos { get; set; }// Tabla Intermedia N:M 

    internal bool IsValid()
    {
        throw new NotImplementedException();
    }
}
