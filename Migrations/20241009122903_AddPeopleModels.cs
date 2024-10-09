using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2024_b1_individueel.Migrations
{
    /// <inheritdoc />
    public partial class AddPeopleModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TutorSet",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TutorSet", x => x.Identifier);
                });

            migrationBuilder.CreateTable(
                name: "PupilSet",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TutorIdentifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PupilSet", x => x.Identifier);
                    table.ForeignKey(
                        name: "FK_PupilSet_TutorSet_TutorIdentifier",
                        column: x => x.TutorIdentifier,
                        principalTable: "TutorSet",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScoreSet",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AchievedByIdentifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AchievedScore = table.Column<int>(type: "int", nullable: false),
                    FlagDeckIdentifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreSet", x => x.Identifier);
                    table.ForeignKey(
                        name: "FK_ScoreSet_FlagDeckSet_FlagDeckIdentifier",
                        column: x => x.FlagDeckIdentifier,
                        principalTable: "FlagDeckSet",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScoreSet_PupilSet_AchievedByIdentifier",
                        column: x => x.AchievedByIdentifier,
                        principalTable: "PupilSet",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PupilSet_TutorIdentifier",
                table: "PupilSet",
                column: "TutorIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_ScoreSet_AchievedByIdentifier",
                table: "ScoreSet",
                column: "AchievedByIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_ScoreSet_FlagDeckIdentifier",
                table: "ScoreSet",
                column: "FlagDeckIdentifier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScoreSet");

            migrationBuilder.DropTable(
                name: "PupilSet");

            migrationBuilder.DropTable(
                name: "TutorSet");
        }
    }
}
