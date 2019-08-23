using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultingManager.Infra.Migrations
{
    public partial class addedmailafterfinishingtask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConferenceRoomAddress",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MailBody",
                table: "ModelTasks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MailSubject",
                table: "ModelTasks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MailBody",
                table: "CustomerTasks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MailSubject",
                table: "CustomerTasks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConferenceRoomAddress",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MailBody",
                table: "ModelTasks");

            migrationBuilder.DropColumn(
                name: "MailSubject",
                table: "ModelTasks");

            migrationBuilder.DropColumn(
                name: "MailBody",
                table: "CustomerTasks");

            migrationBuilder.DropColumn(
                name: "MailSubject",
                table: "CustomerTasks");
        }
    }
}
