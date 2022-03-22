using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Caritas.ServiceAPI.Migrations
{
    public partial class RemovingContacts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sheltereds_GeneralSheltInfo_GeneralSheltInfoId",
                schema: "shelt",
                table: "Sheltereds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GeneralSheltInfo",
                table: "GeneralSheltInfo");

            migrationBuilder.RenameTable(
                name: "GeneralSheltInfo",
                newName: "GeneralSheltInfos",
                newSchema: "shelt");

            migrationBuilder.AddColumn<bool>(
                name: "AcceptsToBeWelcomed",
                schema: "shelt",
                table: "Sheltereds",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "AnotherInstitutionName",
                schema: "shelt",
                table: "Sheltereds",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "BeenAnotherInstitution",
                schema: "shelt",
                table: "Sheltereds",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "City",
                schema: "shelt",
                table: "Sheltereds",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasIncome",
                schema: "shelt",
                table: "Sheltereds",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "HowFindOutShelter",
                schema: "shelt",
                table: "Sheltereds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaritalStatus",
                schema: "shelt",
                table: "Sheltereds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                schema: "shelt",
                table: "Sheltereds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Neighborhood",
                schema: "shelt",
                table: "Sheltereds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResidesIn",
                schema: "shelt",
                table: "Sheltereds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceOfIncome",
                schema: "shelt",
                table: "Sheltereds",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GeneralSheltInfos",
                schema: "shelt",
                table: "GeneralSheltInfos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sheltereds_GeneralSheltInfos_GeneralSheltInfoId",
                schema: "shelt",
                table: "Sheltereds",
                column: "GeneralSheltInfoId",
                principalSchema: "shelt",
                principalTable: "GeneralSheltInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sheltereds_GeneralSheltInfos_GeneralSheltInfoId",
                schema: "shelt",
                table: "Sheltereds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GeneralSheltInfos",
                schema: "shelt",
                table: "GeneralSheltInfos");

            migrationBuilder.DropColumn(
                name: "AcceptsToBeWelcomed",
                schema: "shelt",
                table: "Sheltereds");

            migrationBuilder.DropColumn(
                name: "AnotherInstitutionName",
                schema: "shelt",
                table: "Sheltereds");

            migrationBuilder.DropColumn(
                name: "BeenAnotherInstitution",
                schema: "shelt",
                table: "Sheltereds");

            migrationBuilder.DropColumn(
                name: "City",
                schema: "shelt",
                table: "Sheltereds");

            migrationBuilder.DropColumn(
                name: "HasIncome",
                schema: "shelt",
                table: "Sheltereds");

            migrationBuilder.DropColumn(
                name: "HowFindOutShelter",
                schema: "shelt",
                table: "Sheltereds");

            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                schema: "shelt",
                table: "Sheltereds");

            migrationBuilder.DropColumn(
                name: "Nationality",
                schema: "shelt",
                table: "Sheltereds");

            migrationBuilder.DropColumn(
                name: "Neighborhood",
                schema: "shelt",
                table: "Sheltereds");

            migrationBuilder.DropColumn(
                name: "ResidesIn",
                schema: "shelt",
                table: "Sheltereds");

            migrationBuilder.DropColumn(
                name: "SourceOfIncome",
                schema: "shelt",
                table: "Sheltereds");

            migrationBuilder.RenameTable(
                name: "GeneralSheltInfos",
                schema: "shelt",
                newName: "GeneralSheltInfo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GeneralSheltInfo",
                table: "GeneralSheltInfo",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    Kinship = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Neighborhood = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    ShelteredId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contact_Sheltereds_ShelteredId",
                        column: x => x.ShelteredId,
                        principalSchema: "shelt",
                        principalTable: "Sheltereds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contact_ShelteredId",
                table: "Contact",
                column: "ShelteredId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sheltereds_GeneralSheltInfo_GeneralSheltInfoId",
                schema: "shelt",
                table: "Sheltereds",
                column: "GeneralSheltInfoId",
                principalTable: "GeneralSheltInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
