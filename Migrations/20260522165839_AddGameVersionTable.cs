using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpaceShooterApi.Migrations
{
    /// <inheritdoc />
    public partial class AddGameVersionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameVersions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CurrentVersion = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    DownloadUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    IsMandatory = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameVersions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameVersions");
        }
    }
}
