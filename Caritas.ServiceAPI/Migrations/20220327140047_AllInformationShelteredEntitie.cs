using Microsoft.EntityFrameworkCore.Migrations;

namespace Caritas.ServiceAPI.Migrations
{
    public partial class AllInformationShelteredEntitie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sheltereds_GeneralSheltInfos_GeneralSheltInfoId",
                schema: "shelt",
                table: "Sheltereds");

            migrationBuilder.DropIndex(
                name: "IX_Sheltereds_GeneralSheltInfoId",
                schema: "shelt",
                table: "Sheltereds");

            migrationBuilder.DropColumn(
                name: "GeneralSheltInfoId",
                schema: "shelt",
                table: "Sheltereds");

            migrationBuilder.AddColumn<string>(
                name: "AnyOccurrence",
                schema: "shelt",
                table: "Sheltereds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ControlledMedicine",
                schema: "shelt",
                table: "Sheltereds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Disability",
                schema: "shelt",
                table: "Sheltereds",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Drinker",
                schema: "shelt",
                table: "Sheltereds",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FeedsItself",
                schema: "shelt",
                table: "Sheltereds",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "GoOutAline",
                schema: "shelt",
                table: "Sheltereds",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasMedicalTreatment",
                schema: "shelt",
                table: "Sheltereds",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "HealthProblem",
                schema: "shelt",
                table: "Sheltereds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HowMoves",
                schema: "shelt",
                table: "Sheltereds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MedicalInsurance",
                schema: "shelt",
                table: "Sheltereds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResponsibleAddress",
                schema: "shelt",
                table: "Sheltereds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResponsibleKinship",
                schema: "shelt",
                table: "Sheltereds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResponsibleName",
                schema: "shelt",
                table: "Sheltereds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResponsibleNeighborhood",
                schema: "shelt",
                table: "Sheltereds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResponsiblePhone",
                schema: "shelt",
                table: "Sheltereds",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Smoker",
                schema: "shelt",
                table: "Sheltereds",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "WhichHospital",
                schema: "shelt",
                table: "Sheltereds",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnyOccurrence",
                schema: "shelt",
                table: "Sheltereds");

            migrationBuilder.DropColumn(
                name: "ControlledMedicine",
                schema: "shelt",
                table: "Sheltereds");

            migrationBuilder.DropColumn(
                name: "Disability",
                schema: "shelt",
                table: "Sheltereds");

            migrationBuilder.DropColumn(
                name: "Drinker",
                schema: "shelt",
                table: "Sheltereds");

            migrationBuilder.DropColumn(
                name: "FeedsItself",
                schema: "shelt",
                table: "Sheltereds");

            migrationBuilder.DropColumn(
                name: "GoOutAline",
                schema: "shelt",
                table: "Sheltereds");

            migrationBuilder.DropColumn(
                name: "HasMedicalTreatment",
                schema: "shelt",
                table: "Sheltereds");

            migrationBuilder.DropColumn(
                name: "HealthProblem",
                schema: "shelt",
                table: "Sheltereds");

            migrationBuilder.DropColumn(
                name: "HowMoves",
                schema: "shelt",
                table: "Sheltereds");

            migrationBuilder.DropColumn(
                name: "MedicalInsurance",
                schema: "shelt",
                table: "Sheltereds");

            migrationBuilder.DropColumn(
                name: "ResponsibleAddress",
                schema: "shelt",
                table: "Sheltereds");

            migrationBuilder.DropColumn(
                name: "ResponsibleKinship",
                schema: "shelt",
                table: "Sheltereds");

            migrationBuilder.DropColumn(
                name: "ResponsibleName",
                schema: "shelt",
                table: "Sheltereds");

            migrationBuilder.DropColumn(
                name: "ResponsibleNeighborhood",
                schema: "shelt",
                table: "Sheltereds");

            migrationBuilder.DropColumn(
                name: "ResponsiblePhone",
                schema: "shelt",
                table: "Sheltereds");

            migrationBuilder.DropColumn(
                name: "Smoker",
                schema: "shelt",
                table: "Sheltereds");

            migrationBuilder.DropColumn(
                name: "WhichHospital",
                schema: "shelt",
                table: "Sheltereds");

            migrationBuilder.AddColumn<int>(
                name: "GeneralSheltInfoId",
                schema: "shelt",
                table: "Sheltereds",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sheltereds_GeneralSheltInfoId",
                schema: "shelt",
                table: "Sheltereds",
                column: "GeneralSheltInfoId");

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
    }
}
