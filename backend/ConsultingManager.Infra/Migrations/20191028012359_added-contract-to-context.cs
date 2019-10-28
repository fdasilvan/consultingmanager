using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultingManager.Infra.Migrations
{
    public partial class addedcontracttocontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractPoco_ContractSituations_ContractSituationId",
                table: "ContractPoco");

            migrationBuilder.DropForeignKey(
                name: "FK_ContractPoco_Customers_CustomerId",
                table: "ContractPoco");

            migrationBuilder.DropForeignKey(
                name: "FK_ContractPoco_Plans_PlanId",
                table: "ContractPoco");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerMeetings_ContractPoco_ContractId",
                table: "CustomerMeetings");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerMeetings_ContractPoco_MeetingTypeId",
                table: "CustomerMeetings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContractPoco",
                table: "ContractPoco");

            migrationBuilder.RenameTable(
                name: "ContractPoco",
                newName: "Contracts");

            migrationBuilder.RenameIndex(
                name: "IX_ContractPoco_PlanId",
                table: "Contracts",
                newName: "IX_Contracts_PlanId");

            migrationBuilder.RenameIndex(
                name: "IX_ContractPoco_CustomerId",
                table: "Contracts",
                newName: "IX_Contracts_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_ContractPoco_ContractSituationId",
                table: "Contracts",
                newName: "IX_Contracts_ContractSituationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contracts",
                table: "Contracts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_ContractSituations_ContractSituationId",
                table: "Contracts",
                column: "ContractSituationId",
                principalTable: "ContractSituations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Customers_CustomerId",
                table: "Contracts",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Plans_PlanId",
                table: "Contracts",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerMeetings_Contracts_ContractId",
                table: "CustomerMeetings",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerMeetings_Contracts_MeetingTypeId",
                table: "CustomerMeetings",
                column: "MeetingTypeId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_ContractSituations_ContractSituationId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Customers_CustomerId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Plans_PlanId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerMeetings_Contracts_ContractId",
                table: "CustomerMeetings");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerMeetings_Contracts_MeetingTypeId",
                table: "CustomerMeetings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contracts",
                table: "Contracts");

            migrationBuilder.RenameTable(
                name: "Contracts",
                newName: "ContractPoco");

            migrationBuilder.RenameIndex(
                name: "IX_Contracts_PlanId",
                table: "ContractPoco",
                newName: "IX_ContractPoco_PlanId");

            migrationBuilder.RenameIndex(
                name: "IX_Contracts_CustomerId",
                table: "ContractPoco",
                newName: "IX_ContractPoco_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Contracts_ContractSituationId",
                table: "ContractPoco",
                newName: "IX_ContractPoco_ContractSituationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContractPoco",
                table: "ContractPoco",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractPoco_ContractSituations_ContractSituationId",
                table: "ContractPoco",
                column: "ContractSituationId",
                principalTable: "ContractSituations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContractPoco_Customers_CustomerId",
                table: "ContractPoco",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContractPoco_Plans_PlanId",
                table: "ContractPoco",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
    }
}
