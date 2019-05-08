using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultingManager.Infra.Migrations
{
    public partial class createdcustomerprocessrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerProcesses_ModelProcesses_ProcessId",
                table: "CustomerProcesses");

            migrationBuilder.RenameColumn(
                name: "ProcessId",
                table: "CustomerProcesses",
                newName: "ModelProcessId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerProcesses_ProcessId",
                table: "CustomerProcesses",
                newName: "IX_CustomerProcesses_ModelProcessId");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "CustomerProcesses",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProcesses_CustomerId",
                table: "CustomerProcesses",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerProcesses_Customers_CustomerId",
                table: "CustomerProcesses",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerProcesses_ModelProcesses_ModelProcessId",
                table: "CustomerProcesses",
                column: "ModelProcessId",
                principalTable: "ModelProcesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerProcesses_Customers_CustomerId",
                table: "CustomerProcesses");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerProcesses_ModelProcesses_ModelProcessId",
                table: "CustomerProcesses");

            migrationBuilder.DropIndex(
                name: "IX_CustomerProcesses_CustomerId",
                table: "CustomerProcesses");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "CustomerProcesses");

            migrationBuilder.RenameColumn(
                name: "ModelProcessId",
                table: "CustomerProcesses",
                newName: "ProcessId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerProcesses_ModelProcessId",
                table: "CustomerProcesses",
                newName: "IX_CustomerProcesses_ProcessId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerProcesses_ModelProcesses_ProcessId",
                table: "CustomerProcesses",
                column: "ProcessId",
                principalTable: "ModelProcesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
