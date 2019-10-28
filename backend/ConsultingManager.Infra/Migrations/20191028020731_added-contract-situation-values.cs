using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultingManager.Infra.Migrations
{
    public partial class addedcontractsituationvalues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ContractSituations",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("92b405a1-7ec7-4310-8ef3-be7c4040a94a"), "Ativo" },
                    { new Guid("7ec78f62-0a7f-4fda-bff4-6819e724a8e1"), "Pausado" },
                    { new Guid("9be12448-e253-4c47-ae0d-3f69de0d023a"), "Bloqueado" },
                    { new Guid("bd944220-6985-4bad-a7af-80bbd1bf1084"), "Cancelado" },
                    { new Guid("cb7f761d-dfc6-4bda-a061-239b607d384e"), "Concluído" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContractSituations",
                keyColumn: "Id",
                keyValue: new Guid("7ec78f62-0a7f-4fda-bff4-6819e724a8e1"));

            migrationBuilder.DeleteData(
                table: "ContractSituations",
                keyColumn: "Id",
                keyValue: new Guid("92b405a1-7ec7-4310-8ef3-be7c4040a94a"));

            migrationBuilder.DeleteData(
                table: "ContractSituations",
                keyColumn: "Id",
                keyValue: new Guid("9be12448-e253-4c47-ae0d-3f69de0d023a"));

            migrationBuilder.DeleteData(
                table: "ContractSituations",
                keyColumn: "Id",
                keyValue: new Guid("bd944220-6985-4bad-a7af-80bbd1bf1084"));

            migrationBuilder.DeleteData(
                table: "ContractSituations",
                keyColumn: "Id",
                keyValue: new Guid("cb7f761d-dfc6-4bda-a061-239b607d384e"));
        }
    }
}
