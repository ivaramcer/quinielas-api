using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuinielasApi.Migrations
{
    /// <inheritdoc />
    public partial class WeFixedQuinielasGamesWeUsedNullableValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuinielaGames_NFLGames_NFLGameId",
                table: "QuinielaGames");

            migrationBuilder.DropForeignKey(
                name: "FK_QuinielaGames_SoccerGames_SoccerGameId",
                table: "QuinielaGames");

            migrationBuilder.AlterColumn<int>(
                name: "SoccerGameId",
                table: "QuinielaGames",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "NFLGameId",
                table: "QuinielaGames",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "GroupNumber",
                table: "QuinielaGames",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Group",
                table: "QuinielaGames",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_QuinielaGames_NFLGames_NFLGameId",
                table: "QuinielaGames",
                column: "NFLGameId",
                principalTable: "NFLGames",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuinielaGames_SoccerGames_SoccerGameId",
                table: "QuinielaGames",
                column: "SoccerGameId",
                principalTable: "SoccerGames",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuinielaGames_NFLGames_NFLGameId",
                table: "QuinielaGames");

            migrationBuilder.DropForeignKey(
                name: "FK_QuinielaGames_SoccerGames_SoccerGameId",
                table: "QuinielaGames");

            migrationBuilder.AlterColumn<int>(
                name: "SoccerGameId",
                table: "QuinielaGames",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NFLGameId",
                table: "QuinielaGames",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GroupNumber",
                table: "QuinielaGames",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Group",
                table: "QuinielaGames",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_QuinielaGames_NFLGames_NFLGameId",
                table: "QuinielaGames",
                column: "NFLGameId",
                principalTable: "NFLGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuinielaGames_SoccerGames_SoccerGameId",
                table: "QuinielaGames",
                column: "SoccerGameId",
                principalTable: "SoccerGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
