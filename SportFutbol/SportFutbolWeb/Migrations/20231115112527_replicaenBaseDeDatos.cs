using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportFutbolWeb.Migrations
{
    /// <inheritdoc />
    public partial class replicaenBaseDeDatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagenCancha",
                table: "Cancha",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagenCancha",
                table: "Cancha");
        }
    }
}
