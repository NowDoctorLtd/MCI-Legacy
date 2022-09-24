using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mci_main.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Practitioner",
                columns: table => new
                {
                    MciIdx = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<int>(type: "INTEGER", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    Bio = table.Column<string>(type: "TEXT", nullable: false),
                    DOB = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Practitioner", x => x.MciIdx);
                });

            migrationBuilder.CreateTable(
                name: "Specialty",
                columns: table => new
                {
                    MciIdx = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    LongDescription = table.Column<string>(type: "TEXT", nullable: false),
                    ShortDesc = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialty", x => x.MciIdx);
                });

            migrationBuilder.CreateTable(
                name: "PractitionerSpecialty",
                columns: table => new
                {
                    MciIdx = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PracIdx = table.Column<int>(type: "INTEGER", nullable: false),
                    SpecIdx = table.Column<int>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PractitionerSpecialty", x => x.MciIdx);
                    table.ForeignKey(
                        name: "FK_PractitionerSpecialty_Practitioner_PracIdx",
                        column: x => x.PracIdx,
                        principalTable: "Practitioner",
                        principalColumn: "MciIdx",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PractitionerSpecialty_Specialty_SpecIdx",
                        column: x => x.SpecIdx,
                        principalTable: "Specialty",
                        principalColumn: "MciIdx",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PractitionerSpecialty_PracIdx",
                table: "PractitionerSpecialty",
                column: "PracIdx");

            migrationBuilder.CreateIndex(
                name: "IX_PractitionerSpecialty_SpecIdx",
                table: "PractitionerSpecialty",
                column: "SpecIdx");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PractitionerSpecialty");

            migrationBuilder.DropTable(
                name: "Practitioner");

            migrationBuilder.DropTable(
                name: "Specialty");
        }
    }
}
