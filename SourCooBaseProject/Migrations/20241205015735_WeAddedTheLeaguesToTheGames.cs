using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuinielasApi.Migrations
{
    /// <inheritdoc />
    public partial class WeAddedTheLeaguesToTheGames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LeagueId",
                table: "Games",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Games_LeagueId",
                table: "Games",
                column: "LeagueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Leagues_LeagueId",
                table: "Games",
                column: "LeagueId",
                principalTable: "Leagues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Leagues_LeagueId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_LeagueId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "LeagueId",
                table: "Games");
        }
    }
}
