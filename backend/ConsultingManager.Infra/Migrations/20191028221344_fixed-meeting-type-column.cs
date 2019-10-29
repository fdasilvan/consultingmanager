using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultingManager.Infra.Migrations
{
    public partial class fixedmeetingtypecolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerMeetings_Contracts_MeetingTypeId",
                table: "CustomerMeetings");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerMeetings_MeetingTypes_MeetingTypeId",
                table: "CustomerMeetings",
                column: "MeetingTypeId",
                principalTable: "MeetingTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerMeetings_MeetingTypes_MeetingTypeId",
                table: "CustomerMeetings");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerMeetings_Contracts_MeetingTypeId",
                table: "CustomerMeetings",
                column: "MeetingTypeId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
