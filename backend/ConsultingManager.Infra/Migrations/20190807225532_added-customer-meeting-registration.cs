using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultingManager.Infra.Migrations
{
    public partial class addedcustomermeetingregistration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DaysBetweenMeetings",
                table: "Plans",
                nullable: false,
                defaultValue: 30);

            migrationBuilder.CreateTable(
                name: "CustomerMeetings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OriginalDate = table.Column<DateTime>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerMeetings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerMeetings_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerMeetings_CustomerId",
                table: "CustomerMeetings",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerMeetings");

            migrationBuilder.DropColumn(
                name: "DaysBetweenMeetings",
                table: "Plans");
        }
    }
}
