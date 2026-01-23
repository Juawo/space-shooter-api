using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpaceShooterApi.Migrations
{
    /// <inheritdoc />
    public partial class CascadeDeleteForHighScoreAndPlayer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_HighScores_Players_PlayerId",
                table: "HighScores",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HighScores_Players_PlayerId",
                table: "HighScores");
        }
    }
}
