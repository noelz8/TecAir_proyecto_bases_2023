using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace webApi.Migrations
{
    /// <inheritdoc />
    public partial class ReservacionMaleta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservaciones",
                columns: table => new
                {
                    ReservacionID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClienteID = table.Column<int>(type: "integer", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HoraInicio = table.Column<TimeSpan>(type: "interval", nullable: false),
                    HoraFin = table.Column<TimeSpan>(type: "interval", nullable: false),
                    CantidadPersonas = table.Column<int>(type: "integer", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    Precio = table.Column<decimal>(type: "numeric", nullable: false),
                    PrecioDerivado = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservaciones", x => x.ReservacionID);
                    table.ForeignKey(
                        name: "FK_Reservaciones_Clientes_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "ClienteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Maletas",
                columns: table => new
                {
                    NumeroMaleta = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Peso = table.Column<int>(type: "integer", nullable: false),
                    ReservacionID = table.Column<int>(type: "integer", nullable: false),
                    Dueno = table.Column<string>(type: "text", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false),
                    Precio = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maletas", x => x.NumeroMaleta);
                    table.ForeignKey(
                        name: "FK_Maletas_Reservaciones_ReservacionID",
                        column: x => x.ReservacionID,
                        principalTable: "Reservaciones",
                        principalColumn: "ReservacionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Maletas_ReservacionID",
                table: "Maletas",
                column: "ReservacionID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservaciones_ClienteID",
                table: "Reservaciones",
                column: "ClienteID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Maletas");

            migrationBuilder.DropTable(
                name: "Reservaciones");
        }
    }
}
