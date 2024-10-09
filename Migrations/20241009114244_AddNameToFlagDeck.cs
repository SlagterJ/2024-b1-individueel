using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2024_b1_individueel.Migrations
{
    /// <inheritdoc />
    public partial class AddNameToFlagDeck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "FlagDeckSet",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "FlagDeckSet");
        }
    }
}
