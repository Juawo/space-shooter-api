using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpaceShooterApi.Migrations
{
    /// <inheritdoc />
    public partial class RenameScoresToHighScores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Scores",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Scores");

            migrationBuilder.RenameTable(
                name: "Scores",
                newName: "HighScores");

            migrationBuilder.RenameIndex(
                name: "IX_Scores_PlayerId",
                table: "HighScores",
                newName: "IX_HighScores_PlayerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HighScores",
                table: "HighScores",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HighScores",
                table: "HighScores");

            migrationBuilder.RenameTable(
                name: "HighScores",
                newName: "Scores");

            migrationBuilder.RenameIndex(
                name: "IX_HighScores_PlayerId",
                table: "Scores",
                newName: "IX_Scores_PlayerId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Scores",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Scores",
                table: "Scores",
                column: "Id");
        }
    }
}
