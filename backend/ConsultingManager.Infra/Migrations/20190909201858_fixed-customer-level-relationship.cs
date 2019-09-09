using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultingManager.Infra.Migrations
{
    public partial class fixedcustomerlevelrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CustomerLevelPoco_CustomerLevelId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerLevelPoco",
                table: "CustomerLevelPoco");

            migrationBuilder.RenameTable(
                name: "CustomerLevelPoco",
                newName: "CustomerLevels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerLevels",
                table: "CustomerLevels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CustomerLevels_CustomerLevelId",
                table: "Customers",
                column: "CustomerLevelId",
                principalTable: "CustomerLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CustomerLevels_CustomerLevelId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerLevels",
                table: "CustomerLevels");

            migrationBuilder.RenameTable(
                name: "CustomerLevels",
                newName: "CustomerLevelPoco");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerLevelPoco",
                table: "CustomerLevelPoco",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CustomerLevelPoco_CustomerLevelId",
                table: "Customers",
                column: "CustomerLevelId",
                principalTable: "CustomerLevelPoco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
