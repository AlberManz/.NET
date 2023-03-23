using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class Coches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CocheId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Coches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coches", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_CocheId",
                table: "Users",
                column: "CocheId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Coches_CocheId",
                table: "Users",
                column: "CocheId",
                principalTable: "Coches",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Coches_CocheId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Coches");

            migrationBuilder.DropIndex(
                name: "IX_Users_CocheId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CocheId",
                table: "Users");
        }
    }
}
