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

    public virtual DbSet<Avion> Avions { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Destino> Destinos { get; set; }

    public virtual DbSet<Escala> Escalas { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Maletum> Maleta { get; set; }

    public virtual DbSet<Origen> Origens { get; set; }

    public virtual DbSet<Promocion> Promocions { get; set; }

    public virtual DbSet<Reservacion> Reservacions { get; set; }

    public virtual DbSet<Universidad> Universidads { get; set; }

    public virtual DbSet<Viaje> Viajes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=tecair;Username=postgres;Password=AWjanome30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Avion>(entity =>
        {
            entity.HasKey(e => e.Avionid).HasName("avion_pkey");

            entity.ToTable("avion");

            entity.Property(e => e.Avionid)
                .ValueGeneratedNever()
                .HasColumnName("avionid");
            entity.Property(e => e.Aerolinea)
                .HasMaxLength(255)
                .HasColumnName("aerolinea");
            entity.Property(e => e.Capacidad).HasColumnName("capacidad");
            entity.Property(e => e.Codigoaeropuertodestino)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("codigoaeropuertodestino");
            entity.Property(e => e.Codigoaeropuertoorigen)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("codigoaeropuertoorigen");
            entity.Property(e => e.Imagen)
                .HasMaxLength(255)
                .HasColumnName("imagen");
            entity.Property(e => e.Modelo)
                .HasMaxLength(255)
                .HasColumnName("modelo");

            entity.HasOne(d => d.CodigoaeropuertodestinoNavigation).WithMany(p => p.Avions)
                .HasForeignKey(d => d.Codigoaeropuertodestino)
                .HasConstraintName("avion_codigoaeropuertodestino_fkey");

            entity.HasOne(d => d.CodigoaeropuertoorigenNavigation).WithMany(p => p.Avions)
                .HasForeignKey(d => d.Codigoaeropuertoorigen)
                .HasConstraintName("avion_codigoaeropuertoorigen_fkey");
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
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("apellido2");
            entity.Property(e => e.Correo)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("correo");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Destino>(entity =>
        {
            entity.HasKey(e => e.Codigoaeropuertodestino).HasName("destino_pkey");

            entity.ToTable("destino");

            entity.Property(e => e.Codigoaeropuertodestino)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("codigoaeropuertodestino");
            entity.Property(e => e.Ciudad)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("ciudad");
            entity.Property(e => e.Horallegada).HasColumnName("horallegada");
            entity.Property(e => e.Pais)
                .IsRequired()
                .HasMaxLength(255)
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
                .HasMaxLength(3)
                .HasColumnName("codigoaeropuertoescala");
            entity.Property(e => e.Avionid).HasColumnName("avionid");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(255)
                .HasColumnName("ciudad");
            entity.Property(e => e.Pais)
                .HasMaxLength(255)
                .HasColumnName("pais");
            entity.Property(e => e.Vueloorigen)
                .HasMaxLength(255)
                .HasColumnName("vueloorigen");

            entity.HasOne(d => d.Avion).WithMany(p => p.Escalas)
                .HasForeignKey(d => d.Avionid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("escala_avionid_fkey");
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.Carnet).HasName("estudiante_pkey");

            entity.ToTable("estudiante");

            entity.Property(e => e.Carnet)
                .ValueGeneratedNever()
                .HasColumnName("carnet");
            entity.Property(e => e.Clienteid).HasColumnName("clienteid");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Estudiantes)
                .HasForeignKey(d => d.Clienteid)
                .HasConstraintName("estudiante_clienteid_fkey");
        });

        modelBuilder.Entity<Maletum>(entity =>
        {
            entity.HasKey(e => e.Numero).HasName("maleta_pkey");

            entity.ToTable("maleta");

            entity.Property(e => e.Numero)
                .ValueGeneratedNever()
                .HasColumnName("numero");
            entity.Property(e => e.Color)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("color");
            entity.Property(e => e.Dueño)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("dueño");
            entity.Property(e => e.Peso)
                .HasPrecision(10, 2)
                .HasColumnName("peso");
            entity.Property(e => e.Reservacionid).HasColumnName("reservacionid");

            entity.HasOne(d => d.Reservacion).WithMany(p => p.Maleta)
                .HasForeignKey(d => d.Reservacionid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("maleta_reservacionid_fkey");
        });

        modelBuilder.Entity<Origen>(entity =>
        {
            entity.HasKey(e => e.Codigoaeropuertoorigen).HasName("origen_pkey");

            entity.ToTable("origen");

            entity.Property(e => e.Codigoaeropuertoorigen)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("codigoaeropuertoorigen");
            entity.Property(e => e.Ciudad)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("ciudad");
            entity.Property(e => e.Horasalida).HasColumnName("horasalida");
            entity.Property(e => e.Pais)
                .IsRequired()
                .HasMaxLength(255)
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
                .HasMaxLength(255)
                .HasColumnName("destino");
            entity.Property(e => e.Origen)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("origen");
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

            entity.HasOne(d => d.Cliente).WithMany(p => p.Reservacions)
                .HasForeignKey(d => d.Clienteid)
                .HasConstraintName("reservacion_clienteid_fkey");
        });

        modelBuilder.Entity<Universidad>(entity =>
        {
            entity.HasKey(e => e.Nombre).HasName("universidad_pkey");

            entity.ToTable("universidad");

            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            entity.Property(e => e.Carnet).HasColumnName("carnet");

            entity.HasOne(d => d.CarnetNavigation).WithMany(p => p.Universidads)
                .HasForeignKey(d => d.Carnet)
                .HasConstraintName("universidad_carnet_fkey");
        });

        modelBuilder.Entity<Viaje>(entity =>
        {
            entity.HasKey(e => e.Viajeid).HasName("viaje_pkey");

            entity.ToTable("viaje");

            entity.Property(e => e.Viajeid)
                .ValueGeneratedNever()
                .HasColumnName("viajeid");
            entity.Property(e => e.Avionid).HasColumnName("avionid");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Horario).HasColumnName("horario");
            entity.Property(e => e.Numeroasiento).HasColumnName("numeroasiento");
            entity.Property(e => e.Precio)
                .HasPrecision(10, 2)
                .HasColumnName("precio");
            entity.Property(e => e.Reservacionid).HasColumnName("reservacionid");

            entity.HasOne(d => d.Avion).WithMany(p => p.Viajes)
                .HasForeignKey(d => d.Avionid)
                .HasConstraintName("viaje_avionid_fkey");

            entity.HasOne(d => d.Reservacion).WithMany(p => p.Viajes)
                .HasForeignKey(d => d.Reservacionid)
                .HasConstraintName("viaje_reservacionid_fkey");

            entity.HasMany(d => d.Promocions).WithMany(p => p.Viajes)
                .UsingEntity<Dictionary<string, object>>(
                    "Promocionesporviaje",
                    r => r.HasOne<Promocion>().WithMany()
                        .HasForeignKey("Promocionid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("promocionesporviaje_promocionid_fkey"),
                    l => l.HasOne<Viaje>().WithMany()
                        .HasForeignKey("Viajeid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("promocionesporviaje_viajeid_fkey"),
                    j =>
                    {
                        j.HasKey("Viajeid", "Promocionid").HasName("promocionesporviaje_pkey");
                        j.ToTable("promocionesporviaje");
                        j.IndexerProperty<int>("Viajeid").HasColumnName("viajeid");
                        j.IndexerProperty<int>("Promocionid").HasColumnName("promocionid");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
