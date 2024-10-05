using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace QuinielasApi.Migrations
{
    /// <inheritdoc />
    public partial class SomeFixesForTheDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Preferences_Team_TeamId",
                table: "Preferences");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Preferences_TeamId",
                table: "Preferences");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Preferences");

            migrationBuilder.AddColumn<int>(
                name: "NFLTeamId",
                table: "Preferences",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SoccerTeamId",
                table: "Preferences",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Preferences_NFLTeamId",
                table: "Preferences",
                column: "NFLTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Preferences_SoccerTeamId",
                table: "Preferences",
                column: "SoccerTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Preferences_NFLTeams_NFLTeamId",
                table: "Preferences",
                column: "NFLTeamId",
                principalTable: "NFLTeams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Preferences_SoccerTeams_SoccerTeamId",
                table: "Preferences",
                column: "SoccerTeamId",
                principalTable: "SoccerTeams",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Preferences_NFLTeams_NFLTeamId",
                table: "Preferences");

            migrationBuilder.DropForeignKey(
                name: "FK_Preferences_SoccerTeams_SoccerTeamId",
                table: "Preferences");

            migrationBuilder.DropIndex(
                name: "IX_Preferences_NFLTeamId",
                table: "Preferences");

            migrationBuilder.DropIndex(
                name: "IX_Preferences_SoccerTeamId",
                table: "Preferences");

            migrationBuilder.DropColumn(
                name: "NFLTeamId",
                table: "Preferences");

            migrationBuilder.DropColumn(
                name: "SoccerTeamId",
                table: "Preferences");

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Preferences",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SportId = table.Column<int>(type: "integer", nullable: false),
                    Abbreviation = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    ImageURL = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Team_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AwayTeamId = table.Column<int>(type: "integer", nullable: false),
                    HomeTeamId = table.Column<int>(type: "integer", nullable: false),
                    WinnerTeamId = table.Column<int>(type: "integer", nullable: true),
                    AwayScore = table.Column<int>(type: "integer", nullable: false),
                    ExternalId = table.Column<int>(type: "integer", nullable: false),
                    HomeScore = table.Column<int>(type: "integer", nullable: false),
                    Schedule = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    TeamId = table.Column<int>(type: "integer", nullable: true),
                    Venue = table.Column<string>(type: "text", nullable: false),
                    Week = table.Column<int>(type: "integer", nullable: true),
                    WeekString = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Game_Team_AwayTeamId",
                        column: x => x.AwayTeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Game_Team_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Game_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Game_Team_WinnerTeamId",
                        column: x => x.WinnerTeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Preferences_TeamId",
                table: "Preferences",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_AwayTeamId",
                table: "Game",
                column: "AwayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_HomeTeamId",
                table: "Game",
                column: "HomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_TeamId",
                table: "Game",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_WinnerTeamId",
                table: "Game",
                column: "WinnerTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_SportId",
                table: "Team",
                column: "SportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Preferences_Team_TeamId",
                table: "Preferences",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
