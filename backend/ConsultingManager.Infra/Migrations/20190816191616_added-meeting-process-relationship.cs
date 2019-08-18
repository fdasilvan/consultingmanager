using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultingManager.Infra.Migrations
{
    public partial class addedmeetingprocessrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CustomerMeetingId",
                table: "CustomerProcesses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProcesses_CustomerMeetingId",
                table: "CustomerProcesses",
                column: "CustomerMeetingId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerProcesses_CustomerMeetings_CustomerMeetingId",
                table: "CustomerProcesses",
                column: "CustomerMeetingId",
                principalTable: "CustomerMeetings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerProcesses_CustomerMeetings_CustomerMeetingId",
                table: "CustomerProcesses");

            migrationBuilder.DropIndex(
                name: "IX_CustomerProcesses_CustomerMeetingId",
                table: "CustomerProcesses");

            migrationBuilder.DropColumn(
                name: "CustomerMeetingId",
                table: "CustomerProcesses");
        }
    }
}
