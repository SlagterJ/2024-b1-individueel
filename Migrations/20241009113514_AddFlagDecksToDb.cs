using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2024_b1_individueel.Migrations
{
    /// <inheritdoc />
    public partial class AddFlagDecksToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FlagDeckIdentifier",
                table: "FlagSet",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FlagDeckSet",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlagDeckSet", x => x.Identifier);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlagSet_FlagDeckIdentifier",
                table: "FlagSet",
                column: "FlagDeckIdentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_FlagSet_FlagDeckSet_FlagDeckIdentifier",
                table: "FlagSet",
                column: "FlagDeckIdentifier",
                principalTable: "FlagDeckSet",
                principalColumn: "Identifier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlagSet_FlagDeckSet_FlagDeckIdentifier",
                table: "FlagSet");

            migrationBuilder.DropTable(
                name: "FlagDeckSet");

            migrationBuilder.DropIndex(
                name: "IX_FlagSet_FlagDeckIdentifier",
                table: "FlagSet");

            migrationBuilder.DropColumn(
                name: "FlagDeckIdentifier",
                table: "FlagSet");
        }
    }
}
