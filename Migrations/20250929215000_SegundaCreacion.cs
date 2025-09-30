using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tienda_EFC.Migrations
{
    /// <inheritdoc />
    public partial class SegundaCreacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FKId",
                table: "Servicios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FKId",
                table: "Servicios");
        }
    }
}
