using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpaceShooterApi.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueHighScorePerPlayer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Scores_PlayerId",
                table: "Scores",
                column: "PlayerId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Scores_PlayerId",
                table: "Scores");
        }
    }
}
