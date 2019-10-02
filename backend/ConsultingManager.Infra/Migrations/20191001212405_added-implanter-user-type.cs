using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultingManager.Infra.Migrations
{
    public partial class addedimplanterusertype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "Id", "Description" },
                values: new object[] { new Guid("bb159acc-cb7d-476d-9c45-1a75dafed934"), "Implantador" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: new Guid("bb159acc-cb7d-476d-9c45-1a75dafed934"));
        }
    }
}
