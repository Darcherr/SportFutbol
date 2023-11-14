using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportFutbolWeb.Migrations
{
    /// <inheritdoc />
    public partial class ediTurnos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turno_Cancha_CanchaRefId",
                table: "Turno");

            migrationBuilder.DropIndex(
                name: "IX_Turno_CanchaRefId",
                table: "Turno");

            migrationBuilder.DropColumn(
                name: "CanchaRefId",
                table: "Turno");

            migrationBuilder.CreateIndex(
                name: "IX_Turno_IdCancha",
                table: "Turno",
                column: "IdCancha");

            migrationBuilder.AddForeignKey(
                name: "FK_Turno_Cancha_IdCancha",
                table: "Turno",
                column: "IdCancha",
                principalTable: "Cancha",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turno_Cancha_IdCancha",
                table: "Turno");

            migrationBuilder.DropIndex(
                name: "IX_Turno_IdCancha",
                table: "Turno");

            migrationBuilder.AddColumn<int>(
                name: "CanchaRefId",
                table: "Turno",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Turno_CanchaRefId",
                table: "Turno",
                column: "CanchaRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Turno_Cancha_CanchaRefId",
                table: "Turno",
                column: "CanchaRefId",
                principalTable: "Cancha",
                principalColumn: "ID");
        }
    }
}
