using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsultingManager.Infra.Migrations
{
    public partial class initialdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModelProcesses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelProcesses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModelSteps",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ProcessId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelSteps_ModelProcesses_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "ModelProcesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    Name = table.Column<string>(nullable: true),
                    LogoUrl = table.Column<string>(nullable: true),
                    StoreUrl = table.Column<string>(nullable: true),
                    PlatformId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    UserTypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserTypes_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "UserTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerProcesses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EstimatedEndDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    ModelProcessId = table.Column<Guid>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerProcesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerProcesses_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerProcesses_ModelProcesses_ModelProcessId",
                        column: x => x.ModelProcessId,
                        principalTable: "ModelProcesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerSteps",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EstimatedEndDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    CustomerProcessId = table.Column<Guid>(nullable: false),
                    ModelStepId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerSteps_CustomerProcesses_CustomerProcessId",
                        column: x => x.CustomerProcessId,
                        principalTable: "CustomerProcesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerSteps_ModelSteps_ModelStepId",
                        column: x => x.ModelStepId,
                        principalTable: "ModelSteps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ModelTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Instructions = table.Column<string>(nullable: true),
                    Duration = table.Column<int>(nullable: false),
                    StartAfterDays = table.Column<int>(nullable: false),
                    DueDays = table.Column<int>(nullable: false),
                    TaskTypeId = table.Column<Guid>(nullable: false),
                    CustomerStepId = table.Column<Guid>(nullable: false),
                    ModelStepPocoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelTasks_CustomerSteps_CustomerStepId",
                        column: x => x.CustomerStepId,
                        principalTable: "CustomerSteps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ModelTasks_ModelSteps_ModelStepPocoId",
                        column: x => x.ModelStepPocoId,
                        principalTable: "ModelSteps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ModelTasks_TaskTypes_TaskTypeId",
                        column: x => x.TaskTypeId,
                        principalTable: "TaskTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Instructions = table.Column<string>(nullable: true),
                    Duration = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EstimatedEndDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    CustomerId = table.Column<Guid>(nullable: false),
                    CustomerUserId = table.Column<Guid>(nullable: false),
                    ConsultantId = table.Column<Guid>(nullable: false),
                    OwnerId = table.Column<Guid>(nullable: false),
                    TaskTypeId = table.Column<Guid>(nullable: false),
                    ModelTaskId = table.Column<Guid>(nullable: false),
                    CustomerStepId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerTasks_Users_ConsultantId",
                        column: x => x.ConsultantId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerTasks_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerTasks_CustomerSteps_CustomerStepId",
                        column: x => x.CustomerStepId,
                        principalTable: "CustomerSteps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerTasks_Users_CustomerUserId",
                        column: x => x.CustomerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerTasks_ModelTasks_ModelTaskId",
                        column: x => x.ModelTaskId,
                        principalTable: "ModelTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerTasks_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerTasks_TaskTypes_TaskTypeId",
                        column: x => x.TaskTypeId,
                        principalTable: "TaskTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaskContent",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true),
                    ModelTaskId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskContent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskContent_ModelTasks_ModelTaskId",
                        column: x => x.ModelTaskId,
                        principalTable: "ModelTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("7b64054e-fc81-44e1-a1e2-cfb4bfcf8489"), "Simplo7" });

            migrationBuilder.InsertData(
                table: "TaskTypes",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("e84138fe-a7c6-4724-865f-1c4cab8be234"), "Consultor" },
                    { new Guid("a26f516b-6a6f-4159-8f4e-6ca3193bea95"), "Cliente" }
                });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("d10dd961-e131-4618-a235-8b0116aecc91"), "Administrador" },
                    { new Guid("5f70a257-25a9-42e4-9db3-8623d6e758a5"), "Líder" },
                    { new Guid("70f24307-54b9-41e3-b4fb-4c86e0202ba4"), "Consultor" },
                    { new Guid("43c2e87c-35a8-47c0-a4dd-d233b836dd4a"), "Cliente" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProcesses_CustomerId",
                table: "CustomerProcesses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProcesses_ModelProcessId",
                table: "CustomerProcesses",
                column: "ModelProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PlatformId",
                table: "Customers",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSteps_CustomerProcessId",
                table: "CustomerSteps",
                column: "CustomerProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSteps_ModelStepId",
                table: "CustomerSteps",
                column: "ModelStepId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerTasks_ConsultantId",
                table: "CustomerTasks",
                column: "ConsultantId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerTasks_CustomerId",
                table: "CustomerTasks",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerTasks_CustomerStepId",
                table: "CustomerTasks",
                column: "CustomerStepId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerTasks_CustomerUserId",
                table: "CustomerTasks",
                column: "CustomerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerTasks_ModelTaskId",
                table: "CustomerTasks",
                column: "ModelTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerTasks_OwnerId",
                table: "CustomerTasks",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerTasks_TaskTypeId",
                table: "CustomerTasks",
                column: "TaskTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelSteps_ProcessId",
                table: "ModelSteps",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelTasks_CustomerStepId",
                table: "ModelTasks",
                column: "CustomerStepId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelTasks_ModelStepPocoId",
                table: "ModelTasks",
                column: "ModelStepPocoId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelTasks_TaskTypeId",
                table: "ModelTasks",
                column: "TaskTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskContent_ModelTaskId",
                table: "TaskContent",
                column: "ModelTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeId",
                table: "Users",
                column: "UserTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerTasks");

            migrationBuilder.DropTable(
                name: "TaskContent");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ModelTasks");

            migrationBuilder.DropTable(
                name: "UserTypes");

            migrationBuilder.DropTable(
                name: "CustomerSteps");

            migrationBuilder.DropTable(
                name: "TaskTypes");

            migrationBuilder.DropTable(
                name: "CustomerProcesses");

            migrationBuilder.DropTable(
                name: "ModelSteps");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "ModelProcesses");

            migrationBuilder.DropTable(
                name: "Platforms");
        }
    }
}
