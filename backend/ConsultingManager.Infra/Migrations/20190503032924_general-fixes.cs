using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultingManager.Infra.Migrations
{
    public partial class generalfixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descritpion",
                table: "Processes",
                newName: "Description");

            migrationBuilder.AddColumn<long>(
                name: "DaysToDo",
                table: "TaskTemplates",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Instructions",
                table: "TaskTemplates",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "StartAfterDays",
                table: "TaskTemplates",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerUserId",
                table: "Tasks",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Tasks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Instructions",
                table: "Tasks",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Tasks",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Tasks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Steps",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Steps",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Processes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EstimatedEndDate",
                table: "Processes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Processes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "TaskTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CustomerUserId",
                table: "Tasks",
                column: "CustomerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_CustomerUserId",
                table: "Tasks",
                column: "CustomerUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_OwnerId",
                table: "Tasks",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_CustomerUserId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_OwnerId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "TaskTypes");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_CustomerUserId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "DaysToDo",
                table: "TaskTemplates");

            migrationBuilder.DropColumn(
                name: "Instructions",
                table: "TaskTemplates");

            migrationBuilder.DropColumn(
                name: "StartAfterDays",
                table: "TaskTemplates");

            migrationBuilder.DropColumn(
                name: "CustomerUserId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Instructions",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Steps");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Steps");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Processes");

            migrationBuilder.DropColumn(
                name: "EstimatedEndDate",
                table: "Processes");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Processes");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Processes",
                newName: "Descritpion");
        }
    }
}
