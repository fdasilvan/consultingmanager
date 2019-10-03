using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultingManager.Infra.Migrations
{
    public partial class addedoriginaldatestocustomertask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "OriginalEstimatedEndDate",
                table: "CustomerTasks",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OriginalStartDate",
                table: "CustomerTasks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OriginalEstimatedEndDate",
                table: "CustomerTasks");

            migrationBuilder.DropColumn(
                name: "OriginalStartDate",
                table: "CustomerTasks");
        }
    }
}
