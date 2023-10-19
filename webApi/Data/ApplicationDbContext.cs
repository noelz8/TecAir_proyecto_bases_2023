using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

// Descripción General:
// La clase realiza la conexión con la base de datos
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // ---------- MODELS ----------------
    // Agregar los modelos
    //Clientes
    public DbSet<Cliente> Clientes { get; set; } = new ClientesDbSet();

    //Reservaciones
    public DbSet<Reservacion> Reservaciones { get; set; } = new ReservacionesDbSet();

    // Maletas
    public DbSet<Maleta> Maletas {get; set;} = new MaletasDbSet();

    //Aviones
    public DbSet<Avion> Aviones {get; set;} = new AvionesDbSet();

    //Origenes
    public DbSet<Origen> Origenes {get; set;} = new OrigenesDbSet();

    //Destinos
    public DbSet<Destino> Destinos {get; set;} = new DestinosDbSet();

    // Vuelos
    public DbSet<Vuelo> Vuelos {get; set;} = new VuelosDbSet();

    // Asientos
    public DbSet<Asiento> Asientos  {get; set;} = new AsientosDbSet();


    // Metodos para generar los queries
    public IQueryable<Cliente> GetClientes() => Clientes;

    public IQueryable<Reservacion> GetReservaciones() => Reservaciones;

    public IQueryable<Maleta> GetMaletas() => Maletas;



    /// -------- ENTITY TYPE -------------------------
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



    internal class AvionesDbSet : DbSet<Avion>
    {
        // Devuelve el tipo de entidad de este conjunto.
        public override IEntityType EntityType => (IEntityType)typeof(Avion);
    }

    internal class OrigenesDbSet : DbSet<Origen>
    {
        // Devuelve el tipo de entidad de este conjunto.
        public override IEntityType EntityType => (IEntityType)typeof(Origen);
    }

    internal class DestinosDbSet : DbSet<Destino>
    {
        // Devuelve el tipo de entidad de este conjunto.
        public override IEntityType EntityType => (IEntityType)typeof(Destino);
    }

    internal class VuelosDbSet : DbSet<Vuelo>
    {
        // Devuelve el tipo de entidad de este conjunto.
        public override IEntityType EntityType => (IEntityType)typeof(Vuelo);
    }


    internal class AsientosDbSet : DbSet<Asiento>
    {
        // Devuelve el tipo de entidad de este conjunto.
        public override IEntityType EntityType => (IEntityType)typeof(Asiento);
    }

    
}

