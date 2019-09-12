using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultingManager.Infra.Migrations
{
    public partial class addedcustomerfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerFolderUrl",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeetingsDescription",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StoreAnalysisUrl",
                table: "Customers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerFolderUrl",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "MeetingsDescription",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "StoreAnalysisUrl",
                table: "Customers");
        }
    }
}
