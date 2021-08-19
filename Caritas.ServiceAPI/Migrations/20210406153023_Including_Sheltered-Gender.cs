using Microsoft.EntityFrameworkCore.Migrations;

namespace Caritas.ServiceAPI.Migrations
{
    public partial class Including_ShelteredGender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                schema: "shelt",
                table: "Sheltereds",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                schema: "shelt",
                table: "Sheltereds");
        }
    }
}
