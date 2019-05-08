using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultingManager.Infra.Migrations
{
    public partial class processvssteprelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerSteps_Customers_CustomerId",
                table: "CustomerSteps");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerSteps_ModelProcesses_ProcessId",
                table: "CustomerSteps");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerSteps_ModelSteps_StepId",
                table: "CustomerSteps");

            migrationBuilder.DropIndex(
                name: "IX_CustomerSteps_CustomerId",
                table: "CustomerSteps");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "CustomerSteps");

            migrationBuilder.RenameColumn(
                name: "StepId",
                table: "CustomerSteps",
                newName: "ModelStepId");

            migrationBuilder.RenameColumn(
                name: "ProcessId",
                table: "CustomerSteps",
                newName: "CustomerProcessId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerSteps_StepId",
                table: "CustomerSteps",
                newName: "IX_CustomerSteps_ModelStepId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerSteps_ProcessId",
                table: "CustomerSteps",
                newName: "IX_CustomerSteps_CustomerProcessId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerSteps_CustomerProcesses_CustomerProcessId",
                table: "CustomerSteps",
                column: "CustomerProcessId",
                principalTable: "CustomerProcesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerSteps_ModelSteps_ModelStepId",
                table: "CustomerSteps",
                column: "ModelStepId",
                principalTable: "ModelSteps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerSteps_CustomerProcesses_CustomerProcessId",
                table: "CustomerSteps");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerSteps_ModelSteps_ModelStepId",
                table: "CustomerSteps");

            migrationBuilder.RenameColumn(
                name: "ModelStepId",
                table: "CustomerSteps",
                newName: "StepId");

            migrationBuilder.RenameColumn(
                name: "CustomerProcessId",
                table: "CustomerSteps",
                newName: "ProcessId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerSteps_ModelStepId",
                table: "CustomerSteps",
                newName: "IX_CustomerSteps_StepId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerSteps_CustomerProcessId",
                table: "CustomerSteps",
                newName: "IX_CustomerSteps_ProcessId");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "CustomerSteps",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSteps_CustomerId",
                table: "CustomerSteps",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerSteps_Customers_CustomerId",
                table: "CustomerSteps",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerSteps_ModelProcesses_ProcessId",
                table: "CustomerSteps",
                column: "ProcessId",
                principalTable: "ModelProcesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerSteps_ModelSteps_StepId",
                table: "CustomerSteps",
                column: "StepId",
                principalTable: "ModelSteps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
