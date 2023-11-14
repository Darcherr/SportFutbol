using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportFutbolWeb.Migrations
{
    /// <inheritdoc />
    public partial class turnos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Turno",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IdCancha = table.Column<int>(type: "int", nullable: true),
                    CanchaRefId = table.Column<int>(type: "int", nullable: true),
                    FechaTurno = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    NombreCliente = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turno", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Turno_Cancha_CanchaRefId",
                        column: x => x.CanchaRefId,
                        principalTable: "Cancha",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Turno_CanchaRefId",
                table: "Turno",
                column: "CanchaRefId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Turno");
        }
    }
}
