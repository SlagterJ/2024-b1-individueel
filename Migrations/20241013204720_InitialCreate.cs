using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _2024_b1_individueel.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlagDeckSet",
                columns: table => new
                {
                    Identifier = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlagDeckSet", x => x.Identifier);
                });

            migrationBuilder.CreateTable(
                name: "FlagSet",
                columns: table => new
                {
                    Identifier = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CorrectAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlagDeckIdentifier = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlagSet", x => x.Identifier);
                    table.ForeignKey(
                        name: "FK_FlagSet_FlagDeckSet_FlagDeckIdentifier",
                        column: x => x.FlagDeckIdentifier,
                        principalTable: "FlagDeckSet",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScoreSet",
                columns: table => new
                {
                    Identifier = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AchievedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AchievedScore = table.Column<int>(type: "int", nullable: true),
                    FlagDeckIdentifier = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreSet", x => x.Identifier);
                    table.ForeignKey(
                        name: "FK_ScoreSet_FlagDeckSet_FlagDeckIdentifier",
                        column: x => x.FlagDeckIdentifier,
                        principalTable: "FlagDeckSet",
                        principalColumn: "Identifier");
                });

            migrationBuilder.InsertData(
                table: "FlagDeckSet",
                columns: new[] { "Identifier", "Name" },
                values: new object[,]
                {
                    { 1, "Europa" },
                    { 2, "Noord-Amerika" }
                });

            migrationBuilder.InsertData(
                table: "FlagSet",
                columns: new[] { "Identifier", "CorrectAnswer", "CountryCode", "FlagDeckIdentifier" },
                values: new object[,]
                {
                    { 1, "Nederland", "nl", 1 },
                    { 2, "België", "be", 1 },
                    { 3, "Duitsland", "de", 1 },
                    { 4, "Canada", "ca", 2 },
                    { 5, "Verenigde Staten", "us", 2 }
                });

            migrationBuilder.InsertData(
                table: "ScoreSet",
                columns: new[] { "Identifier", "AchievedBy", "AchievedScore", "FlagDeckIdentifier" },
                values: new object[] { 1, "Jordy", 2, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_FlagDeckSet_Name",
                table: "FlagDeckSet",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FlagSet_CountryCode",
                table: "FlagSet",
                column: "CountryCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FlagSet_FlagDeckIdentifier",
                table: "FlagSet",
                column: "FlagDeckIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_ScoreSet_FlagDeckIdentifier",
                table: "ScoreSet",
                column: "FlagDeckIdentifier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlagSet");

            migrationBuilder.DropTable(
                name: "ScoreSet");

            migrationBuilder.DropTable(
                name: "FlagDeckSet");
        }
    }
}
