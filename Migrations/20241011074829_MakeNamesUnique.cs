using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2024_b1_individueel.Migrations
{
    /// <inheritdoc />
    public partial class MakeNamesUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlagSet_FlagDeckSet_FlagDeckIdentifier",
                table: "FlagSet");

            migrationBuilder.AlterColumn<Guid>(
                name: "FlagDeckIdentifier",
                table: "FlagSet",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CountryCode",
                table: "FlagSet",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "FlagDeckSet",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_FlagSet_CountryCode",
                table: "FlagSet",
                column: "CountryCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FlagDeckSet_Name",
                table: "FlagDeckSet",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FlagSet_FlagDeckSet_FlagDeckIdentifier",
                table: "FlagSet",
                column: "FlagDeckIdentifier",
                principalTable: "FlagDeckSet",
                principalColumn: "Identifier",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlagSet_FlagDeckSet_FlagDeckIdentifier",
                table: "FlagSet");

            migrationBuilder.DropIndex(
                name: "IX_FlagSet_CountryCode",
                table: "FlagSet");

            migrationBuilder.DropIndex(
                name: "IX_FlagDeckSet_Name",
                table: "FlagDeckSet");

            migrationBuilder.AlterColumn<Guid>(
                name: "FlagDeckIdentifier",
                table: "FlagSet",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "CountryCode",
                table: "FlagSet",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "FlagDeckSet",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_FlagSet_FlagDeckSet_FlagDeckIdentifier",
                table: "FlagSet",
                column: "FlagDeckIdentifier",
                principalTable: "FlagDeckSet",
                principalColumn: "Identifier");
        }
    }
}
