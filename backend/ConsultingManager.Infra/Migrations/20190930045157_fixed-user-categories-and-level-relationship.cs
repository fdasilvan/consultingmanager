using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultingManager.Infra.Migrations
{
    public partial class fixedusercategoriesandlevelrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCustomerCategory");

            migrationBuilder.DropTable(
                name: "UserCustomerLevel");

            migrationBuilder.CreateTable(
                name: "UserCustomerCategories",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    CustomerCategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCustomerCategories", x => new { x.UserId, x.CustomerCategoryId });
                    table.ForeignKey(
                        name: "FK_UserCustomerCategories_CustomerCategories_CustomerCategoryId",
                        column: x => x.CustomerCategoryId,
                        principalTable: "CustomerCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserCustomerCategories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserCustomerLevels",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    CustomerLevelId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCustomerLevels", x => new { x.UserId, x.CustomerLevelId });
                    table.ForeignKey(
                        name: "FK_UserCustomerLevels_CustomerLevels_CustomerLevelId",
                        column: x => x.CustomerLevelId,
                        principalTable: "CustomerLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserCustomerLevels_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCustomerCategories_CustomerCategoryId",
                table: "UserCustomerCategories",
                column: "CustomerCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCustomerLevels_CustomerLevelId",
                table: "UserCustomerLevels",
                column: "CustomerLevelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCustomerCategories");

            migrationBuilder.DropTable(
                name: "UserCustomerLevels");

            migrationBuilder.CreateTable(
                name: "UserCustomerCategory",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    CustomerCategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCustomerCategory", x => new { x.UserId, x.CustomerCategoryId });
                    table.ForeignKey(
                        name: "FK_UserCustomerCategory_CustomerCategories_CustomerCategoryId",
                        column: x => x.CustomerCategoryId,
                        principalTable: "CustomerCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserCustomerCategory_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserCustomerLevel",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    CustomerLevelId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCustomerLevel", x => new { x.UserId, x.CustomerLevelId });
                    table.ForeignKey(
                        name: "FK_UserCustomerLevel_CustomerLevels_CustomerLevelId",
                        column: x => x.CustomerLevelId,
                        principalTable: "CustomerLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserCustomerLevel_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCustomerCategory_CustomerCategoryId",
                table: "UserCustomerCategory",
                column: "CustomerCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCustomerLevel_CustomerLevelId",
                table: "UserCustomerLevel",
                column: "CustomerLevelId");
        }
    }
}
