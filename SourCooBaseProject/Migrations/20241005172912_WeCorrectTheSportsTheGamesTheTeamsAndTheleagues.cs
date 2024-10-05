using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace QuinielasApi.Migrations
{
    /// <inheritdoc />
    public partial class WeCorrectTheSportsTheGamesTheTeamsAndTheleagues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Team_AwayTeamId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Team_HomeTeamId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Team_TeamId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Team_WinnerTeamId",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Games",
                table: "Games");

            migrationBuilder.RenameTable(
                name: "Games",
                newName: "Game");

            migrationBuilder.RenameIndex(
                name: "IX_Games_WinnerTeamId",
                table: "Game",
                newName: "IX_Game_WinnerTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_TeamId",
                table: "Game",
                newName: "IX_Game_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_HomeTeamId",
                table: "Game",
                newName: "IX_Game_HomeTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_AwayTeamId",
                table: "Game",
                newName: "IX_Game_AwayTeamId");

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "SoccerLeagues",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "SoccerLeagues",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Game",
                table: "Game",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "NFLLeagues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ImageURL = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NFLLeagues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NFLTeams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Abbreviation = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    ImageURL = table.Column<string>(type: "text", nullable: false),
                    NFLLeagueId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NFLTeams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NFLTeams_NFLLeagues_NFLLeagueId",
                        column: x => x.NFLLeagueId,
                        principalTable: "NFLLeagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoccerTeams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Abbreviation = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    ImageURL = table.Column<string>(type: "text", nullable: false),
                    NFLLeagueId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoccerTeams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoccerTeams_NFLLeagues_NFLLeagueId",
                        column: x => x.NFLLeagueId,
                        principalTable: "NFLLeagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NFLGames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Schedule = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Venue = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Week = table.Column<int>(type: "integer", nullable: true),
                    WeekString = table.Column<string>(type: "text", nullable: false),
                    HomeTeamId = table.Column<int>(type: "integer", nullable: false),
                    HomeScore = table.Column<int>(type: "integer", nullable: false),
                    AwayTeamId = table.Column<int>(type: "integer", nullable: false),
                    AwayScore = table.Column<int>(type: "integer", nullable: false),
                    WinnerTeamId = table.Column<int>(type: "integer", nullable: true),
                    NFLTeamId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NFLGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NFLGames_NFLTeams_AwayTeamId",
                        column: x => x.AwayTeamId,
                        principalTable: "NFLTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NFLGames_NFLTeams_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalTable: "NFLTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NFLGames_NFLTeams_NFLTeamId",
                        column: x => x.NFLTeamId,
                        principalTable: "NFLTeams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NFLGames_NFLTeams_WinnerTeamId",
                        column: x => x.WinnerTeamId,
                        principalTable: "NFLTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "SoccerGames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Schedule = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Venue = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Week = table.Column<int>(type: "integer", nullable: true),
                    WeekString = table.Column<string>(type: "text", nullable: false),
                    HomeTeamId = table.Column<int>(type: "integer", nullable: false),
                    HomeScore = table.Column<int>(type: "integer", nullable: false),
                    AwayTeamId = table.Column<int>(type: "integer", nullable: false),
                    AwayScore = table.Column<int>(type: "integer", nullable: false),
                    WinnerTeamId = table.Column<int>(type: "integer", nullable: true),
                    IsDraw = table.Column<bool>(type: "boolean", nullable: false),
                    SoccerTeamId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoccerGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoccerGames_SoccerTeams_AwayTeamId",
                        column: x => x.AwayTeamId,
                        principalTable: "SoccerTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SoccerGames_SoccerTeams_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalTable: "SoccerTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SoccerGames_SoccerTeams_SoccerTeamId",
                        column: x => x.SoccerTeamId,
                        principalTable: "SoccerTeams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SoccerGames_SoccerTeams_WinnerTeamId",
                        column: x => x.WinnerTeamId,
                        principalTable: "SoccerTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NFLGames_AwayTeamId",
                table: "NFLGames",
                column: "AwayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_NFLGames_HomeTeamId",
                table: "NFLGames",
                column: "HomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_NFLGames_NFLTeamId",
                table: "NFLGames",
                column: "NFLTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_NFLGames_WinnerTeamId",
                table: "NFLGames",
                column: "WinnerTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_NFLTeams_NFLLeagueId",
                table: "NFLTeams",
                column: "NFLLeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_SoccerGames_AwayTeamId",
                table: "SoccerGames",
                column: "AwayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_SoccerGames_HomeTeamId",
                table: "SoccerGames",
                column: "HomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_SoccerGames_SoccerTeamId",
                table: "SoccerGames",
                column: "SoccerTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_SoccerGames_WinnerTeamId",
                table: "SoccerGames",
                column: "WinnerTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_SoccerTeams_NFLLeagueId",
                table: "SoccerTeams",
                column: "NFLLeagueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Team_AwayTeamId",
                table: "Game",
                column: "AwayTeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Team_HomeTeamId",
                table: "Game",
                column: "HomeTeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Team_TeamId",
                table: "Game",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Team_WinnerTeamId",
                table: "Game",
                column: "WinnerTeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Team_AwayTeamId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_Team_HomeTeamId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_Team_TeamId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_Team_WinnerTeamId",
                table: "Game");

            migrationBuilder.DropTable(
                name: "NFLGames");

            migrationBuilder.DropTable(
                name: "SoccerGames");

            migrationBuilder.DropTable(
                name: "NFLTeams");

            migrationBuilder.DropTable(
                name: "SoccerTeams");

            migrationBuilder.DropTable(
                name: "NFLLeagues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Game",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "SoccerLeagues");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "SoccerLeagues");

            migrationBuilder.RenameTable(
                name: "Game",
                newName: "Games");

            migrationBuilder.RenameIndex(
                name: "IX_Game_WinnerTeamId",
                table: "Games",
                newName: "IX_Games_WinnerTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Game_TeamId",
                table: "Games",
                newName: "IX_Games_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Game_HomeTeamId",
                table: "Games",
                newName: "IX_Games_HomeTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Game_AwayTeamId",
                table: "Games",
                newName: "IX_Games_AwayTeamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Games",
                table: "Games",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Team_AwayTeamId",
                table: "Games",
                column: "AwayTeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Team_HomeTeamId",
                table: "Games",
                column: "HomeTeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Team_TeamId",
                table: "Games",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Team_WinnerTeamId",
                table: "Games",
                column: "WinnerTeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
