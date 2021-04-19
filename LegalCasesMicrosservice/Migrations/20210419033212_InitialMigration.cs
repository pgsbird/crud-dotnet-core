using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LegalCasesMicrosservice.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LegalCases",
                columns: table => new
                {
                    LegalCaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CourtName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameOfResponsible = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalCases", x => x.LegalCaseId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_CaseNumber",
                table: "LegalCases",
                column: "CaseNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LegalCases");
        }
    }
}
