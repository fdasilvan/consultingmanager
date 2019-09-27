using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultingManager.Infra.Migrations
{
    public partial class addedplanmeetingdescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MeetingsDescription",
                table: "Plans",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeetingsDescription",
                table: "Plans");
        }
    }
}
