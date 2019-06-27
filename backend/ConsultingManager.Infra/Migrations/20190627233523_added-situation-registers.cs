using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultingManager.Infra.Migrations
{
    public partial class addedsituationregisters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CustomerSituationPoco",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("dd57b16a-ccf9-4da1-8d3b-d24e59251aff"), "Ativo" },
                    { new Guid("11a6435d-be18-4427-af65-428eef70c23b"), "Pausado" },
                    { new Guid("3668344d-2bfa-4c36-aa91-5d7a42cb651f"), "Bloqueado" },
                    { new Guid("eb71c684-a336-4985-a50f-923b3f439387"), "Cancelado" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CustomerSituationPoco",
                keyColumn: "Id",
                keyValue: new Guid("11a6435d-be18-4427-af65-428eef70c23b"));

            migrationBuilder.DeleteData(
                table: "CustomerSituationPoco",
                keyColumn: "Id",
                keyValue: new Guid("3668344d-2bfa-4c36-aa91-5d7a42cb651f"));

            migrationBuilder.DeleteData(
                table: "CustomerSituationPoco",
                keyColumn: "Id",
                keyValue: new Guid("dd57b16a-ccf9-4da1-8d3b-d24e59251aff"));

            migrationBuilder.DeleteData(
                table: "CustomerSituationPoco",
                keyColumn: "Id",
                keyValue: new Guid("eb71c684-a336-4985-a50f-923b3f439387"));
        }
    }
}
