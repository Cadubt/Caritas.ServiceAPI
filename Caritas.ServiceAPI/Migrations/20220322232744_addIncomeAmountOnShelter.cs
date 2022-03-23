using Microsoft.EntityFrameworkCore.Migrations;

namespace Caritas.ServiceAPI.Migrations
{
    public partial class addIncomeAmountOnShelter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Contact",
                newName: "Contacts",
                newSchema: "shelt");

            migrationBuilder.AddColumn<decimal>(
                name: "IncomeAmount",
                schema: "shelt",
                table: "Sheltereds",
                nullable: true,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts",
                schema: "shelt",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "IncomeAmount",
                schema: "shelt",
                table: "Sheltereds");

            migrationBuilder.RenameTable(
                name: "Contacts",
                schema: "shelt",
                newName: "Contact");

            migrationBuilder.AddColumn<int>(
                name: "ShelteredId",
                table: "Contact",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contact",
                table: "Contact",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_ShelteredId",
                table: "Contact",
                column: "ShelteredId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Sheltereds_ShelteredId",
                table: "Contact",
                column: "ShelteredId",
                principalSchema: "shelt",
                principalTable: "Sheltereds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
