using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2024_b1_individueel.Migrations
{
    /// <inheritdoc />
    public partial class CorrectAnswersToCorrectAnswer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CorrectAnswers",
                table: "FlagSet",
                newName: "CorrectAnswer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CorrectAnswer",
                table: "FlagSet",
                newName: "CorrectAnswers");
        }
    }
}
