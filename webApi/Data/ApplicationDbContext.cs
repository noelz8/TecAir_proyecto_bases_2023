using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using webApi.Models;
namespace webApi.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aeropuerto> Aeropuertos { get; set; }

    public virtual DbSet<Asiento> Asientos { get; set; }

    public virtual DbSet<Avion> Aviones { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Destino> Destinos { get; set; }

    public virtual DbSet<Escala> Escalas { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Maletum> Maleta { get; set; }

    public virtual DbSet<Origen> Origenes { get; set; }

    public virtual DbSet<Promocion> Promociones { get; set; }

    public virtual DbSet<Promocionesporviaje> Promocionesporviajes { get; set; }

    public virtual DbSet<Reservacion> Reservacions { get; set; }

    public virtual DbSet<Reservacionesporviaje> Reservacionesporviajes { get; set; }

    public virtual DbSet<Universidad> Universidades { get; set; }

    public virtual DbSet<Viaje> Viajes { get; set; }

    public virtual DbSet<Vuelo> Vuelos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=tecair;Username=postgres;Password=AWjanome30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aeropuerto>(entity =>
        {
            entity.HasKey(e => e.Codigoaeropuerto).HasName("aeropuerto_pkey");

            entity.ToTable("aeropuerto");

            entity.Property(e => e.Codigoaeropuerto)
                .HasMaxLength(10)
                .HasColumnName("codigoaeropuerto");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(100)
                .HasColumnName("ciudad");
            entity.Property(e => e.Pais)
                .HasMaxLength(100)
                .HasColumnName("pais");
        });

        modelBuilder.Entity<Asiento>(entity =>
        {
            entity.HasKey(e => e.Asientoid).HasName("asiento_pkey");

            entity.ToTable("asiento");

            entity.Property(e => e.Asientoid)
                .ValueGeneratedNever()
                .HasColumnName("asientoid");
            entity.Property(e => e.Avionid).HasColumnName("avionid");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasColumnName("estado");
            entity.Property(e => e.Posicionasiento)
                .HasMaxLength(10)
                .HasColumnName("posicionasiento");


        });

        modelBuilder.Entity<Avion>(entity =>
        {
            entity.HasKey(e => e.Avionid).HasName("avion_pkey");

            entity.ToTable("avion");

            entity.Property(e => e.Avionid)
                .ValueGeneratedNever()
                .HasColumnName("avionid");
            entity.Property(e => e.Aerolinea)
                .HasMaxLength(100)
                .HasColumnName("aerolinea");
            entity.Property(e => e.Capacidad).HasColumnName("capacidad");
            entity.Property(e => e.Imagen).HasColumnName("imagen");
            entity.Property(e => e.Modelo)
                .HasMaxLength(100)
                .HasColumnName("modelo");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Clienteid).HasName("cliente_pkey");

            entity.ToTable("cliente");

            entity.HasIndex(e => e.Correo, "cliente_correo_key").IsUnique();

            entity.Property(e => e.Clienteid)
                .ValueGeneratedNever()
                .HasColumnName("clienteid");
            entity.Property(e => e.Apellido1)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("apellido1");
            entity.Property(e => e.Apellido2)
                .HasMaxLength(50)
                .HasColumnName("apellido2");
            entity.Property(e => e.Contraseña)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("contraseña");
            entity.Property(e => e.Correo)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("correo");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Destino>(entity =>
        {
            entity.HasKey(e => e.Codigoaeropuerto).HasName("destino_pkey");

            entity.ToTable("destino");

            entity.Property(e => e.Codigoaeropuerto)
                .HasMaxLength(10)
                .HasColumnName("codigoaeropuerto");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(100)
                .HasColumnName("ciudad");
            entity.Property(e => e.Pais)
                .HasMaxLength(100)
                .HasColumnName("pais");
            entity.Property(e => e.Puertaingreso)
                .HasMaxLength(10)
                .HasColumnName("puertaingreso");


        });

        modelBuilder.Entity<Escala>(entity =>
        {
            entity.HasKey(e => e.Codigoaeropuertoescala).HasName("escala_pkey");

            entity.ToTable("escala");

            entity.Property(e => e.Codigoaeropuertoescala)
                .HasMaxLength(10)
                .HasColumnName("codigoaeropuertoescala");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(100)
                .HasColumnName("ciudad");
            entity.Property(e => e.Pais)
                .HasMaxLength(100)
                .HasColumnName("pais");
            entity.Property(e => e.Vueloid).HasColumnName("vueloid");
            entity.Property(e => e.Vueloorigen)
                .HasMaxLength(100)
                .HasColumnName("vueloorigen");


        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.Carnet).HasName("estudiante_pkey");

            entity.ToTable("estudiante");

            entity.Property(e => e.Carnet)
                .HasMaxLength(20)
                .HasColumnName("carnet");
            entity.Property(e => e.Cantidaddeviajes).HasColumnName("cantidaddeviajes");
            entity.Property(e => e.Clienteid).HasColumnName("clienteid");
            entity.Property(e => e.Millas)
                .HasComputedColumnSql("(cantidaddeviajes * 100)", true)
                .HasColumnName("millas");


        });

        modelBuilder.Entity<Maletum>(entity =>
        {
            entity.HasKey(e => e.Numero).HasName("maleta_pkey");

            entity.ToTable("maleta");

            entity.Property(e => e.Numero)
                .ValueGeneratedNever()
                .HasColumnName("numero");
            entity.Property(e => e.Clienteid).HasColumnName("clienteid");
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .HasColumnName("color");
            entity.Property(e => e.Peso)
                .HasPrecision(5, 2)
                .HasColumnName("peso");
            entity.Property(e => e.Reservacionid).HasColumnName("reservacionid");


        });

        modelBuilder.Entity<Origen>(entity =>
        {
            entity.HasKey(e => e.Codigoaeropuerto).HasName("origen_pkey");

            entity.ToTable("origen");

            entity.Property(e => e.Codigoaeropuerto)
                .HasMaxLength(10)
                .HasColumnName("codigoaeropuerto");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(100)
                .HasColumnName("ciudad");
            entity.Property(e => e.Pais)
                .HasMaxLength(100)
                .HasColumnName("pais");
            entity.Property(e => e.Puertaingreso)
                .HasMaxLength(10)
                .HasColumnName("puertaingreso");


        });

        modelBuilder.Entity<Promocion>(entity =>
        {
            entity.HasKey(e => e.Promocionid).HasName("promocion_pkey");

            entity.ToTable("promocion");

            entity.Property(e => e.Promocionid)
                .ValueGeneratedNever()
                .HasColumnName("promocionid");
            entity.Property(e => e.Destino)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("destino");
            entity.Property(e => e.Origen)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("origen");
        });

        modelBuilder.Entity<Promocionesporviaje>(entity =>
        {
            entity.HasKey(e => new { e.Viajeid, e.Promocionid }).HasName("promocionesporviaje_pkey");

            entity.ToTable("promocionesporviaje");

            entity.Property(e => e.Viajeid).HasColumnName("viajeid");
            entity.Property(e => e.Promocionid).HasColumnName("promocionid");
            entity.Property(e => e.Periodo).HasColumnName("periodo");


        });

        modelBuilder.Entity<Reservacion>(entity =>
        {
            entity.HasKey(e => e.Reservacionid).HasName("reservacion_pkey");

            entity.ToTable("reservacion");

            entity.Property(e => e.Reservacionid)
                .ValueGeneratedNever()
                .HasColumnName("reservacionid");
            entity.Property(e => e.Año).HasColumnName("año");
            entity.Property(e => e.Cantidadmaletas).HasColumnName("cantidadmaletas");
            entity.Property(e => e.Clienteid).HasColumnName("clienteid");
            entity.Property(e => e.Dia).HasColumnName("dia");
            entity.Property(e => e.Mes).HasColumnName("mes");


        });

        modelBuilder.Entity<Reservacionesporviaje>(entity =>
        {
            entity.HasKey(e => new { e.Viajeid, e.Reservacionid }).HasName("reservacionesporviaje_pkey");

            entity.ToTable("reservacionesporviaje");

            entity.Property(e => e.Viajeid).HasColumnName("viajeid");
            entity.Property(e => e.Reservacionid).HasColumnName("reservacionid");
            entity.Property(e => e.Numerodeasiento).HasColumnName("numerodeasiento");


        });

        modelBuilder.Entity<Universidad>(entity =>
        {
            entity.HasKey(e => e.Nombre).HasName("universidad_pkey");

            entity.ToTable("universidad");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Carnetestudiante)
                .HasMaxLength(20)
                .HasColumnName("carnetestudiante");


        });

        modelBuilder.Entity<Viaje>(entity =>
        {
            entity.HasKey(e => e.Viajeid).HasName("viaje_pkey");

            entity.ToTable("viaje");

            entity.Property(e => e.Viajeid)
                .ValueGeneratedNever()
                .HasColumnName("viajeid");
            entity.Property(e => e.Estado)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("estado");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Horario)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("horario");
            entity.Property(e => e.Precio)
                .HasPrecision(10, 2)
                .HasColumnName("precio");
        });

        modelBuilder.Entity<Vuelo>(entity =>
        {
            entity.HasKey(e => e.Vueloid).HasName("vuelo_pkey");

            entity.ToTable("vuelo");

            entity.Property(e => e.Vueloid)
                .ValueGeneratedNever()
                .HasColumnName("vueloid");
            entity.Property(e => e.Avionid).HasColumnName("avionid");
            entity.Property(e => e.Codigoaeropuertodestino)
                .HasMaxLength(10)
                .HasColumnName("codigoaeropuertodestino");
            entity.Property(e => e.Codigoaeropuertoorigen)
                .HasMaxLength(10)
                .HasColumnName("codigoaeropuertoorigen");
            entity.Property(e => e.Destino)
                .HasMaxLength(100)
                .HasColumnName("destino");
            entity.Property(e => e.Origen)
                .HasMaxLength(100)
                .HasColumnName("origen");
            entity.Property(e => e.Viajeid).HasColumnName("viajeid");

        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
