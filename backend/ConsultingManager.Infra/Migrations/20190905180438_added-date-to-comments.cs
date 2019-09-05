using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultingManager.Infra.Migrations
{
    public partial class addeddatetocomments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commentaries_Customers_CustomerId",
                table: "Commentaries");

            migrationBuilder.DropForeignKey(
                name: "FK_Commentaries_CustomerTasks_CustomerTaskId",
                table: "Commentaries");

            migrationBuilder.DropForeignKey(
                name: "FK_Commentaries_CustomerMeetings_MeetingId",
                table: "Commentaries");

            migrationBuilder.DropForeignKey(
                name: "FK_Commentaries_Users_UserId",
                table: "Commentaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Commentaries",
                table: "Commentaries");

            migrationBuilder.RenameTable(
                name: "Commentaries",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_Commentaries_UserId",
                table: "Comments",
                newName: "IX_Comments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Commentaries_MeetingId",
                table: "Comments",
                newName: "IX_Comments_MeetingId");

            migrationBuilder.RenameIndex(
                name: "IX_Commentaries_CustomerTaskId",
                table: "Comments",
                newName: "IX_Comments_CustomerTaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Commentaries_CustomerId",
                table: "Comments",
                newName: "IX_Comments_CustomerId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Comments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Customers_CustomerId",
                table: "Comments",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_CustomerTasks_CustomerTaskId",
                table: "Comments",
                column: "CustomerTaskId",
                principalTable: "CustomerTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_CustomerMeetings_MeetingId",
                table: "Comments",
                column: "MeetingId",
                principalTable: "CustomerMeetings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Customers_CustomerId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_CustomerTasks_CustomerTaskId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_CustomerMeetings_MeetingId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Commentaries");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserId",
                table: "Commentaries",
                newName: "IX_Commentaries_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_MeetingId",
                table: "Commentaries",
                newName: "IX_Commentaries_MeetingId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_CustomerTaskId",
                table: "Commentaries",
                newName: "IX_Commentaries_CustomerTaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_CustomerId",
                table: "Commentaries",
                newName: "IX_Commentaries_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Commentaries",
                table: "Commentaries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Commentaries_Customers_CustomerId",
                table: "Commentaries",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Commentaries_CustomerTasks_CustomerTaskId",
                table: "Commentaries",
                column: "CustomerTaskId",
                principalTable: "CustomerTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Commentaries_CustomerMeetings_MeetingId",
                table: "Commentaries",
                column: "MeetingId",
                principalTable: "CustomerMeetings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Commentaries_Users_UserId",
                table: "Commentaries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
