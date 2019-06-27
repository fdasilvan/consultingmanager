using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultingManager.Infra.Migrations
{
    public partial class addedcustomerinformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ConsultantId",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PlanId",
                table: "Customers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Duration = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CategoryId",
                table: "Customers",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ConsultantId",
                table: "Customers",
                column: "ConsultantId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PlanId",
                table: "Customers",
                column: "PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CustomerCategories_CategoryId",
                table: "Customers",
                column: "CategoryId",
                principalTable: "CustomerCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Users_ConsultantId",
                table: "Customers",
                column: "ConsultantId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Plans_PlanId",
                table: "Customers",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CustomerCategories_CategoryId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Users_ConsultantId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Plans_PlanId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "CustomerCategories");

            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CategoryId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ConsultantId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_PlanId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ConsultantId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PlanId",
                table: "Customers");
        }
    }
}
