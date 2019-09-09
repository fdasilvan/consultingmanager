using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultingManager.Infra.Migrations
{
    public partial class addedcustomerlevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CustomerLevelId",
                table: "Customers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CustomerLevelPoco",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<Guid>(nullable: false),
                    RevenueLowLimit = table.Column<decimal>(nullable: false),
                    RevenueHighLimit = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerLevelPoco", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerLevelId",
                table: "Customers",
                column: "CustomerLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CustomerLevelPoco_CustomerLevelId",
                table: "Customers",
                column: "CustomerLevelId",
                principalTable: "CustomerLevelPoco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CustomerLevelPoco_CustomerLevelId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "CustomerLevelPoco");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CustomerLevelId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerLevelId",
                table: "Customers");
        }
    }
}
