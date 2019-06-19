using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultingManager.Infra.Migrations
{
    public partial class taskcontentupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "URL",
                table: "TaskContent",
                newName: "VideoUrl");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "TaskContent",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "TaskContent",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "TaskContent",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Body",
                table: "TaskContent");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "TaskContent");

            migrationBuilder.RenameColumn(
                name: "VideoUrl",
                table: "TaskContent",
                newName: "URL");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "TaskContent",
                newName: "Description");
        }
    }
}
