using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultingManager.Infra.Migrations
{
    public partial class addedenabledcolumntomodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "ModelTasks",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "ModelSteps",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "ModelProcesses",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "ModelTasks");

            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "ModelSteps");

            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "ModelProcesses");
        }
    }
}
