using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B_Analysis_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class MatchUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Matches",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "Matches",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "scoreBlue",
                table: "Matches",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "scoreRed",
                table: "Matches",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "scoreBlue",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "scoreRed",
                table: "Matches");
        }
    }
}
