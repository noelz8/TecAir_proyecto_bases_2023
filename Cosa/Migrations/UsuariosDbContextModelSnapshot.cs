﻿// <auto-generated />
using Cosa.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Cosa.Migrations
{
    [DbContext(typeof(UsuariosDbContext))]
    partial class UsuariosDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Cosa.Models.Rusuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("apellido");

                    b.Property<string>("Apellido2")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("apellido2");

                    b.Property<string>("Carnet")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("carnet");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("contraseña");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("rol");

                    b.Property<int>("Telefono")
                        .HasColumnType("integer")
                        .HasColumnName("telefono");

                    b.Property<string>("Universidad")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("universidad");

                    b.HasKey("Id");

                    b.ToTable("usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
