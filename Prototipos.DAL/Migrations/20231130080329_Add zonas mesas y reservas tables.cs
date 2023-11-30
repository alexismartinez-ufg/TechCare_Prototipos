using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prototipos.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Addzonasmesasyreservastables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Zonas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreZona = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zonas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mesas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreMesa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Personas = table.Column<int>(type: "int", nullable: true),
                    IdZona = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mesas_Zonas_IdZona",
                        column: x => x.IdZona,
                        principalTable: "Zonas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMesa = table.Column<int>(type: "int", nullable: true),
                    PersonaACargo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contacto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaReserva = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoReserva = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservas_Mesas_IdMesa",
                        column: x => x.IdMesa,
                        principalTable: "Mesas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mesas_IdZona",
                table: "Mesas",
                column: "IdZona");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_IdMesa",
                table: "Reservas",
                column: "IdMesa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Mesas");

            migrationBuilder.DropTable(
                name: "Zonas");
        }
    }
}
