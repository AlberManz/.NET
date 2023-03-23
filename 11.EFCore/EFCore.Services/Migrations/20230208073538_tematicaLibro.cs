using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Services.Migrations
{
    public partial class tematicaLibro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tematica",
                table: "Libros",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tematica",
                table: "Libros");
        }
    }
}
