using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultingManager.Infra.Migrations
{
    public partial class addedcustomersituationtodbset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CustomerSituationPoco_SituationId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerSituationPoco",
                table: "CustomerSituationPoco");

            migrationBuilder.RenameTable(
                name: "CustomerSituationPoco",
                newName: "CustomerSituations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerSituations",
                table: "CustomerSituations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CustomerSituations_SituationId",
                table: "Customers",
                column: "SituationId",
                principalTable: "CustomerSituations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CustomerSituations_SituationId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerSituations",
                table: "CustomerSituations");

            migrationBuilder.RenameTable(
                name: "CustomerSituations",
                newName: "CustomerSituationPoco");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerSituationPoco",
                table: "CustomerSituationPoco",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CustomerSituationPoco_SituationId",
                table: "Customers",
                column: "SituationId",
                principalTable: "CustomerSituationPoco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
