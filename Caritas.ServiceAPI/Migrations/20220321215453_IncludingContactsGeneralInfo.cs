using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Caritas.ServiceAPI.Migrations
{
    public partial class IncludingContactsGeneralInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApprovalStatus",
                schema: "shelt",
                table: "Sheltereds",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GeneralSheltInfoId",
                schema: "shelt",
                table: "Sheltereds",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Contact",
                schema: "shelt",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Kinship = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Neighborhood = table.Column<string>(nullable: true),
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

            migrationBuilder.CreateTable(
                name: "GeneralSheltInfo",
                schema: "shelt",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HealthProblem = table.Column<string>(nullable: true),
                    MedicalInsurance = table.Column<string>(nullable: true),
                    HasMedicalTreatment = table.Column<bool>(nullable: false),
                    WhichHospital = table.Column<string>(nullable: true),
                    Disability = table.Column<string>(nullable: true),
                    HowMoves = table.Column<string>(nullable: true),
                    Smoker = table.Column<bool>(nullable: false),
                    Drinker = table.Column<bool>(nullable: false),
                    FeedsItself = table.Column<bool>(nullable: false),
                    ControlledMedicine = table.Column<string>(nullable: true),
                    GoOutAline = table.Column<bool>(nullable: false),
                    AnyOccurrence = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralSheltInfo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sheltereds_GeneralSheltInfoId",
                schema: "shelt",
                table: "Sheltereds",
                column: "GeneralSheltInfoId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sheltereds_GeneralSheltInfo_GeneralSheltInfoId",
                schema: "shelt",
                table: "Sheltereds");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "GeneralSheltInfo");

            migrationBuilder.DropIndex(
                name: "IX_Sheltereds_GeneralSheltInfoId",
                schema: "shelt",
                table: "Sheltereds");

            migrationBuilder.DropColumn(
                name: "ApprovalStatus",
                schema: "shelt",
                table: "Sheltereds");

            migrationBuilder.DropColumn(
                name: "GeneralSheltInfoId",
                schema: "shelt",
                table: "Sheltereds");
        }
    }
}
