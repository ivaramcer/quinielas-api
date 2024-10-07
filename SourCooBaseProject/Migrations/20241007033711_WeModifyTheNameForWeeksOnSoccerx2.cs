using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuinielasApi.Migrations
{
    /// <inheritdoc />
    public partial class WeModifyTheNameForWeeksOnSoccerx2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WeekString",
                table: "SoccerGames",
                newName: "RoundName");

            migrationBuilder.RenameColumn(
                name: "Week",
                table: "SoccerGames",
                newName: "Round");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoundName",
                table: "SoccerGames",
                newName: "WeekString");

            migrationBuilder.RenameColumn(
                name: "Round",
                table: "SoccerGames",
                newName: "Week");
        }
    }
}
