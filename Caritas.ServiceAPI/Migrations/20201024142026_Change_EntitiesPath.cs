using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Caritas.ServiceAPI.Migrations
{
    public partial class Change_EntitiesPath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeceaseAt",
                schema: "shelt",
                table: "Sheltereds",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                schema: "shelt",
                table: "Sheltereds",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeceaseAt",
                schema: "shelt",
                table: "Sheltereds");

            migrationBuilder.DropColumn(
                name: "StatusId",
                schema: "shelt",
                table: "Sheltereds");
        }
    }
}
