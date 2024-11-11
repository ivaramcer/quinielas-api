using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuinielasApi.Migrations
{
    /// <inheritdoc />
    public partial class ModifyEntitiesForGetQuinielasAndPoints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LeagueId",
                table: "Quinielas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuotaPeopleFilled",
                table: "Quinielas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "Gamepasses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Quinielas_LeagueId",
                table: "Quinielas",
                column: "LeagueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quinielas_Leagues_LeagueId",
                table: "Quinielas",
                column: "LeagueId",
                principalTable: "Leagues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quinielas_Leagues_LeagueId",
                table: "Quinielas");

            migrationBuilder.DropIndex(
                name: "IX_Quinielas_LeagueId",
                table: "Quinielas");

            migrationBuilder.DropColumn(
                name: "LeagueId",
                table: "Quinielas");

            migrationBuilder.DropColumn(
                name: "QuotaPeopleFilled",
                table: "Quinielas");

            migrationBuilder.DropColumn(
                name: "Points",
                table: "Gamepasses");
        }
    }
}
