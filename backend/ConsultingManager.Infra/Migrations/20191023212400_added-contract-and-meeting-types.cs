using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultingManager.Infra.Migrations
{
    public partial class addedcontractandmeetingtypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AllowGroupMeeting",
                table: "Plans",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ConsultingFrequency",
                table: "Plans",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ConsultingQuantity",
                table: "Plans",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImplantationFrequency",
                table: "Plans",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImplantationQuantity",
                table: "Plans",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReviewFrequency",
                table: "Plans",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReviewQuantity",
                table: "Plans",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ContractId",
                table: "CustomerMeetings",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFinished",
                table: "CustomerMeetings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "MeetingTypeId",
                table: "CustomerMeetings",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ContractSituations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractSituations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeetingTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContractPoco",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: true),
                    PlanId = table.Column<Guid>(nullable: true),
                    ContractSituationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractPoco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractPoco_ContractSituations_ContractSituationId",
                        column: x => x.ContractSituationId,
                        principalTable: "ContractSituations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContractPoco_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContractPoco_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "MeetingTypes",
                columns: new[] { "Id", "Description" },
                values: new object[] { new Guid("0a5d9561-6518-47a5-89f3-034f4d0256cd"), "Implantação" });

            migrationBuilder.InsertData(
                table: "MeetingTypes",
                columns: new[] { "Id", "Description" },
                values: new object[] { new Guid("38cbb2dd-e1a9-4535-a00a-dcd81cf4fd82"), "Consultoria" });

            migrationBuilder.InsertData(
                table: "MeetingTypes",
                columns: new[] { "Id", "Description" },
                values: new object[] { new Guid("c203d729-d70a-4bb8-853a-879ef62dabe1"), "Acompanhamento" });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerMeetings_ContractId",
                table: "CustomerMeetings",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerMeetings_MeetingTypeId",
                table: "CustomerMeetings",
                column: "MeetingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractPoco_ContractSituationId",
                table: "ContractPoco",
                column: "ContractSituationId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractPoco_CustomerId",
                table: "ContractPoco",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractPoco_PlanId",
                table: "ContractPoco",
                column: "PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerMeetings_ContractPoco_ContractId",
                table: "CustomerMeetings",
                column: "ContractId",
                principalTable: "ContractPoco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerMeetings_ContractPoco_MeetingTypeId",
                table: "CustomerMeetings",
                column: "MeetingTypeId",
                principalTable: "ContractPoco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerMeetings_ContractPoco_ContractId",
                table: "CustomerMeetings");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerMeetings_ContractPoco_MeetingTypeId",
                table: "CustomerMeetings");

            migrationBuilder.DropTable(
                name: "ContractPoco");

            migrationBuilder.DropTable(
                name: "MeetingTypes");

            migrationBuilder.DropTable(
                name: "ContractSituations");

            migrationBuilder.DropIndex(
                name: "IX_CustomerMeetings_ContractId",
                table: "CustomerMeetings");

            migrationBuilder.DropIndex(
                name: "IX_CustomerMeetings_MeetingTypeId",
                table: "CustomerMeetings");

            migrationBuilder.DropColumn(
                name: "AllowGroupMeeting",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "ConsultingFrequency",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "ConsultingQuantity",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "ImplantationFrequency",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "ImplantationQuantity",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "ReviewFrequency",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "ReviewQuantity",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "CustomerMeetings");

            migrationBuilder.DropColumn(
                name: "IsFinished",
                table: "CustomerMeetings");

            migrationBuilder.DropColumn(
                name: "MeetingTypeId",
                table: "CustomerMeetings");
        }
    }
}
