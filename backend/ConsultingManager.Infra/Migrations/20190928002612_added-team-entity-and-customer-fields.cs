using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultingManager.Infra.Migrations
{
    public partial class addedteamentityandcustomerfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExternalId",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subcategory",
                table: "Customers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CustomerSituations",
                columns: new[] { "Id", "Description" },
                values: new object[] { new Guid("241b42ea-05c7-4e7f-81b0-758a688e1a56"), "Contrato Concluído" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Description" },
                values: new object[] { new Guid("7f186fca-eeb3-48d8-a0f0-7387545eb60d"), "Implantação" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Description" },
                values: new object[] { new Guid("eedcaac4-6db4-4bb1-b102-5493d0116183"), "Consultoria" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DeleteData(
                table: "CustomerSituations",
                keyColumn: "Id",
                keyValue: new Guid("241b42ea-05c7-4e7f-81b0-758a688e1a56"));

            migrationBuilder.DropColumn(
                name: "ExternalId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Subcategory",
                table: "Customers");
        }
    }
}
