using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
  public partial class RolesUsuario : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AddColumn<int>(
          name: "RoleId",
          table: "Users",
          type: "int",
          nullable: false,
          defaultValue: 1); // Esto es el valor que va a poner por defecto. Si lo dejamos en 1 todos los que se vayan metiendo tendrán ese role

      migrationBuilder.CreateTable(
          name: "Roles",
          columns: table => new
          {
            Id = table.Column<int>(type: "int", nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            Description = table.Column<int>(type: "int", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Roles", x => x.Id);
          });

      // Esto lo ha tenido que escribir porque ha metido un usuario a mano antes de tener los roles.
      // Lo dejamos porque vale para meter datos en una BD al arranque
      migrationBuilder.InsertData(
        table: "Roles",
        columns: new[] { "Description" },
        values: new object[,]
        {
          { "Admin" }
        });

      migrationBuilder.CreateIndex(
          name: "IX_Users_RoleId",
          table: "Users",
          column: "RoleId");

      migrationBuilder.AddForeignKey(
          name: "FK_Users_Roles_RoleId",
          table: "Users",
          column: "RoleId",
          principalTable: "Roles",
          principalColumn: "Id",
          onDelete: ReferentialAction.Cascade);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
          name: "FK_Users_Roles_RoleId",
          table: "Users");

      migrationBuilder.DropTable(
          name: "Roles");

      migrationBuilder.DropIndex(
          name: "IX_Users_RoleId",
          table: "Users");

      migrationBuilder.DropColumn(
          name: "RoleId",
          table: "Users");
    }
  }
}
