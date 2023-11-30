using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prototipos.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CuentaTablev2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cuentas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMesa = table.Column<int>(type: "int", nullable: true),
                    IdMesero = table.Column<int>(type: "int", nullable: true),
                    ComensalACargo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CantidadPersonas = table.Column<int>(type: "int", nullable: true),
                    FechaAsignacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoCuenta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCuentaPadre = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuentas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cuentas_Cuentas_IdCuentaPadre",
                        column: x => x.IdCuentaPadre,
                        principalTable: "Cuentas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cuentas_Mesas_IdMesa",
                        column: x => x.IdMesa,
                        principalTable: "Mesas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cuentas_Usuarios_IdMesero",
                        column: x => x.IdMesero,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_IdCuentaPadre",
                table: "Cuentas",
                column: "IdCuentaPadre");

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_IdMesa",
                table: "Cuentas",
                column: "IdMesa");

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_IdMesero",
                table: "Cuentas",
                column: "IdMesero");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cuentas");
        }
    }
}
