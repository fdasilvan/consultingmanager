using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultingManager.Infra.Migrations
{
    public partial class createusertypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("d10dd961-e131-4618-a235-8b0116aecc91"), "Administrador" },
                    { new Guid("5f70a257-25a9-42e4-9db3-8623d6e758a5"), "Líder" },
                    { new Guid("70f24307-54b9-41e3-b4fb-4c86e0202ba4"), "Consultor" },
                    { new Guid("43c2e87c-35a8-47c0-a4dd-d233b836dd4a"), "Cliente" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: new Guid("43c2e87c-35a8-47c0-a4dd-d233b836dd4a"));

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: new Guid("5f70a257-25a9-42e4-9db3-8623d6e758a5"));

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: new Guid("70f24307-54b9-41e3-b4fb-4c86e0202ba4"));

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: new Guid("d10dd961-e131-4618-a235-8b0116aecc91"));
        }
    }
}
