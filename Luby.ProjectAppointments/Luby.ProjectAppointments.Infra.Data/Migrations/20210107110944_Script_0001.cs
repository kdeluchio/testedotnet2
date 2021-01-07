using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Luby.ProjectAppointments.Infra.Data.Migrations
{
    public partial class Script_0001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Developer",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedIn = table.Column<DateTime>(nullable: false),
                    UpdatedIn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    CPF = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedIn = table.Column<DateTime>(nullable: false),
                    UpdatedIn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedIn = table.Column<DateTime>(nullable: false),
                    UpdatedIn = table.Column<DateTime>(nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    DeveloperId = table.Column<Guid>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointment_Developer_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LinkedDeveloper",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedIn = table.Column<DateTime>(nullable: false),
                    UpdatedIn = table.Column<DateTime>(nullable: true),
                    ProjectId = table.Column<Guid>(nullable: false),
                    DeveloperId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkedDeveloper", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinkedDeveloper_Developer_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LinkedDeveloper_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_DeveloperId",
                table: "Appointment",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_ProjectId",
                table: "Appointment",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkedDeveloper_DeveloperId",
                table: "LinkedDeveloper",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkedDeveloper_ProjectId",
                table: "LinkedDeveloper",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "LinkedDeveloper");

            migrationBuilder.DropTable(
                name: "Developer");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
