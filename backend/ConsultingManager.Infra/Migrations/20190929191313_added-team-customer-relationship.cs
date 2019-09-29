using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultingManager.Infra.Migrations
{
    public partial class addedteamcustomerrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TeamId",
                table: "Customers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_TeamId",
                table: "Customers",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Teams_TeamId",
                table: "Customers",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Teams_TeamId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_TeamId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Customers");
        }
    }
}
