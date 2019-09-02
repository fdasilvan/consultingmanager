using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultingManager.Infra.Migrations
{
    public partial class fixedprocessdetailrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Detail",
                table: "CustomerTasks");

            migrationBuilder.AddColumn<string>(
                name: "Detail",
                table: "CustomerProcesses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Detail",
                table: "CustomerProcesses");

            migrationBuilder.AddColumn<string>(
                name: "Detail",
                table: "CustomerTasks",
                nullable: true);
        }
    }
}
