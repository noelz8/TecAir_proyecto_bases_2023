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
    public DbSet<Reservacion> Reservaciones { get; set; } = new ReservacionesDbSet();

    public DbSet<Maleta> Maletas {get; set;} = new MaletasDbSet();

    public IQueryable<Cliente> GetClientes() => Clientes;


    // Clase ClientesDbSet representa el conjunto de clientes
    internal class ClientesDbSet : DbSet<Cliente>
    {
        // Devuelve el tipo de entidad de este conjunto.
        public override IEntityType EntityType => (IEntityType)typeof(Cliente);
    }

    // Clase ReservacionesDbSet representa el conjunto de reservaciones
    internal class ReservacionesDbSet : DbSet<Reservacion>
    {
        // Devuelve el tipo de entidad de este conjunto.
        public override IEntityType EntityType => (IEntityType)typeof(Reservacion);
    }

        internal class MaletasDbSet : DbSet<Maleta>
    {
        // Devuelve el tipo de entidad de este conjunto.
        public override IEntityType EntityType => (IEntityType)typeof(Maleta);
    }
}

