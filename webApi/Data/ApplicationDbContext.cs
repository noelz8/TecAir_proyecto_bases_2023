using Microsoft.EntityFrameworkCore; 

// Descripción General:
// La clase realiza la conexión con la base de datos
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    // Agregar los modelos
    public DbSet<Cliente>? Clientes { get; set; } // Se define a la clase cliente para ingresar al DB
    
}