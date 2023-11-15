using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportFutbolWeb.Migrations
{
    /// <inheritdoc />
    public partial class actualizoentidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdTarifa",
                table: "Turno",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Turno_IdTarifa",
                table: "Turno",
                column: "IdTarifa");

            migrationBuilder.AddForeignKey(
                name: "FK_Turno_Tarifa_IdTarifa",
                table: "Turno",
                column: "IdTarifa",
                principalTable: "Tarifa",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turno_Tarifa_IdTarifa",
                table: "Turno");

            migrationBuilder.DropIndex(
                name: "IX_Turno_IdTarifa",
                table: "Turno");

            migrationBuilder.DropColumn(
                name: "IdTarifa",
                table: "Turno");
        }
    }
}
