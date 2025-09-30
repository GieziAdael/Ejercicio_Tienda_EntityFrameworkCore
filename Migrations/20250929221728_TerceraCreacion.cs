using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tienda_EFC.Migrations
{
    /// <inheritdoc />
    public partial class TerceraCreacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Suscripcions",
                table: "Suscripcions");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Suscripcions");

            migrationBuilder.RenameTable(
                name: "Suscripcions",
                newName: "Suscripciones");

            migrationBuilder.RenameColumn(
                name: "DuracionDays",
                table: "Servicios",
                newName: "DurationDays");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suscripciones",
                table: "Suscripciones",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Suscripciones",
                table: "Suscripciones");

            migrationBuilder.RenameTable(
                name: "Suscripciones",
                newName: "Suscripcions");

            migrationBuilder.RenameColumn(
                name: "DurationDays",
                table: "Servicios",
                newName: "DuracionDays");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Suscripcions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suscripcions",
                table: "Suscripcions",
                column: "Id");
        }
    }
}
