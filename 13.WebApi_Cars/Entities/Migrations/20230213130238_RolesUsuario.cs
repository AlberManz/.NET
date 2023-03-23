﻿using Microsoft.EntityFrameworkCore.Migrations;

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
				defaultValue: 1);

			migrationBuilder.CreateTable(
				name: "Roles",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Roles", x => x.Id);
				});

			migrationBuilder.InsertData(
				table: "Roles",
				columns: new[] { "Descripcion" },
				values: new object[,]
				{
					{"Admin"}
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
