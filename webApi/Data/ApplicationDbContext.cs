using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Descripción General:
// La clase realiza la conexión con la base de datos
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    // Agregar los modelos
    public DbSet<Cliente> Clientes { get; set; } = new ClientesDbSet();

    public IQueryable<Cliente> GetClientes() => Clientes;

    internal class ClientesDbSet : DbSet<Cliente>
    {
        public override IEntityType EntityType => (IEntityType)typeof(Cliente);
    }
}

