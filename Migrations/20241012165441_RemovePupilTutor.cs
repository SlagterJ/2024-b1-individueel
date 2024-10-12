using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2024_b1_individueel.Migrations
{
    /// <inheritdoc />
    public partial class RemovePupilTutor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScoreSet_PupilSet_AchievedByIdentifier",
                table: "ScoreSet");

            migrationBuilder.DropTable(
                name: "PupilSet");

            migrationBuilder.DropTable(
                name: "TutorSet");

            migrationBuilder.DropIndex(
                name: "IX_ScoreSet_AchievedByIdentifier",
                table: "ScoreSet");

            migrationBuilder.DropColumn(
                name: "AchievedByIdentifier",
                table: "ScoreSet");

            migrationBuilder.AddColumn<string>(
                name: "AchievedBy",
                table: "ScoreSet",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AchievedBy",
                table: "ScoreSet");

            migrationBuilder.AddColumn<Guid>(
                name: "AchievedByIdentifier",
                table: "ScoreSet",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.CreateIndex(
                name: "IX_ScoreSet_AchievedByIdentifier",
                table: "ScoreSet",
                column: "AchievedByIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_PupilSet_TutorIdentifier",
                table: "PupilSet",
                column: "TutorIdentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_ScoreSet_PupilSet_AchievedByIdentifier",
                table: "ScoreSet",
                column: "AchievedByIdentifier",
                principalTable: "PupilSet",
                principalColumn: "Identifier",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
