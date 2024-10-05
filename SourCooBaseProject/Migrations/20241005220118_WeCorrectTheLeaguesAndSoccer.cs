using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuinielasApi.Migrations
{
    /// <inheritdoc />
    public partial class WeCorrectTheLeaguesAndSoccer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoccerTeams_NFLLeagues_NFLLeagueId",
                table: "SoccerTeams");

            migrationBuilder.RenameColumn(
                name: "NFLLeagueId",
                table: "SoccerTeams",
                newName: "SoccerLeagueId");

            migrationBuilder.RenameIndex(
                name: "IX_SoccerTeams_NFLLeagueId",
                table: "SoccerTeams",
                newName: "IX_SoccerTeams_SoccerLeagueId");

            migrationBuilder.AddForeignKey(
                name: "FK_SoccerTeams_SoccerLeagues_SoccerLeagueId",
                table: "SoccerTeams",
                column: "SoccerLeagueId",
                principalTable: "SoccerLeagues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoccerTeams_SoccerLeagues_SoccerLeagueId",
                table: "SoccerTeams");

            migrationBuilder.RenameColumn(
                name: "SoccerLeagueId",
                table: "SoccerTeams",
                newName: "NFLLeagueId");

            migrationBuilder.RenameIndex(
                name: "IX_SoccerTeams_SoccerLeagueId",
                table: "SoccerTeams",
                newName: "IX_SoccerTeams_NFLLeagueId");

            migrationBuilder.AddForeignKey(
                name: "FK_SoccerTeams_NFLLeagues_NFLLeagueId",
                table: "SoccerTeams",
                column: "NFLLeagueId",
                principalTable: "NFLLeagues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
