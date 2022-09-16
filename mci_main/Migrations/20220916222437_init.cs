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
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "date('now')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Practitioner", x => x.MciIdx);
                });

            migrationBuilder.CreateTable(
                name: "Specialisation",
                columns: table => new
                {
                    MciIdx = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    LongDescription = table.Column<string>(type: "TEXT", nullable: false),
                    ShortDesc = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialisation", x => x.MciIdx);
                });

            migrationBuilder.CreateTable(
                name: "PractitionerSpecialty",
                columns: table => new
                {
                    PractitionersMciIdx = table.Column<int>(type: "INTEGER", nullable: false),
                    SpecialtiesMciIdx = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PractitionerSpecialty", x => new { x.PractitionersMciIdx, x.SpecialtiesMciIdx });
                    table.ForeignKey(
                        name: "FK_PractitionerSpecialty_Practitioner_PractitionersMciIdx",
                        column: x => x.PractitionersMciIdx,
                        principalTable: "Practitioner",
                        principalColumn: "MciIdx",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PractitionerSpecialty_Specialisation_SpecialtiesMciIdx",
                        column: x => x.SpecialtiesMciIdx,
                        principalTable: "Specialisation",
                        principalColumn: "MciIdx",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PractitionerSpecialty_SpecialtiesMciIdx",
                table: "PractitionerSpecialty",
                column: "SpecialtiesMciIdx");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PractitionerSpecialty");

            migrationBuilder.DropTable(
                name: "Practitioner");

            migrationBuilder.DropTable(
                name: "Specialisation");
        }
    }
}
