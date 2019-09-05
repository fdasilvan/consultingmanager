using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultingManager.Infra.Migrations
{
    public partial class fixedcustomermeetingcolumnname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_CustomerMeetings_MeetingId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "MeetingId",
                table: "Comments",
                newName: "CustomerMeetingId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_MeetingId",
                table: "Comments",
                newName: "IX_Comments_CustomerMeetingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_CustomerMeetings_CustomerMeetingId",
                table: "Comments",
                column: "CustomerMeetingId",
                principalTable: "CustomerMeetings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_CustomerMeetings_CustomerMeetingId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "CustomerMeetingId",
                table: "Comments",
                newName: "MeetingId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_CustomerMeetingId",
                table: "Comments",
                newName: "IX_Comments_MeetingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_CustomerMeetings_MeetingId",
                table: "Comments",
                column: "MeetingId",
                principalTable: "CustomerMeetings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
