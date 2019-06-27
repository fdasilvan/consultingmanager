using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultingManager.Infra.Migrations
{
    public partial class addedcustomersituation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CityId",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SituationId",
                table: "Customers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CustomerSituationPoco",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerSituationPoco", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CityId",
                table: "Customers",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_SituationId",
                table: "Customers",
                column: "SituationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CustomerCategories_CityId",
                table: "Customers",
                column: "CityId",
                principalTable: "CustomerCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CustomerSituationPoco_SituationId",
                table: "Customers",
                column: "SituationId",
                principalTable: "CustomerSituationPoco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CustomerCategories_CityId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CustomerSituationPoco_SituationId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "CustomerSituationPoco");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CityId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_SituationId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "SituationId",
                table: "Customers");
        }
    }
}
