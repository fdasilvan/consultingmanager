using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultingManager.Infra.Migrations
{
    public partial class fixmodeltaskrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModelTasks_CustomerSteps_CustomerStepId",
                table: "ModelTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_ModelTasks_ModelSteps_ModelStepPocoId",
                table: "ModelTasks");

            migrationBuilder.DropIndex(
                name: "IX_ModelTasks_ModelStepPocoId",
                table: "ModelTasks");

            migrationBuilder.DropColumn(
                name: "ModelStepPocoId",
                table: "ModelTasks");

            migrationBuilder.RenameColumn(
                name: "CustomerStepId",
                table: "ModelTasks",
                newName: "ModelStepId");

            migrationBuilder.RenameIndex(
                name: "IX_ModelTasks_CustomerStepId",
                table: "ModelTasks",
                newName: "IX_ModelTasks_ModelStepId");

            migrationBuilder.AddForeignKey(
                name: "FK_ModelTasks_ModelSteps_ModelStepId",
                table: "ModelTasks",
                column: "ModelStepId",
                principalTable: "ModelSteps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModelTasks_ModelSteps_ModelStepId",
                table: "ModelTasks");

            migrationBuilder.RenameColumn(
                name: "ModelStepId",
                table: "ModelTasks",
                newName: "CustomerStepId");

            migrationBuilder.RenameIndex(
                name: "IX_ModelTasks_ModelStepId",
                table: "ModelTasks",
                newName: "IX_ModelTasks_CustomerStepId");

            migrationBuilder.AddColumn<Guid>(
                name: "ModelStepPocoId",
                table: "ModelTasks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ModelTasks_ModelStepPocoId",
                table: "ModelTasks",
                column: "ModelStepPocoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ModelTasks_CustomerSteps_CustomerStepId",
                table: "ModelTasks",
                column: "CustomerStepId",
                principalTable: "CustomerSteps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ModelTasks_ModelSteps_ModelStepPocoId",
                table: "ModelTasks",
                column: "ModelStepPocoId",
                principalTable: "ModelSteps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
