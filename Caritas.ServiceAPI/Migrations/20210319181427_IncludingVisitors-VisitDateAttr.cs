using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Caritas.ServiceAPI.Migrations
{
    public partial class IncludingVisitorsVisitDateAttr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "VisitDate",
                schema: "shelt",
                table: "Visitors",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VisitDate",
                schema: "shelt",
                table: "Visitors");
        }
    }
}
