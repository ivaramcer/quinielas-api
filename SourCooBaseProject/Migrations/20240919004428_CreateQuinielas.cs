using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuinielasApi.Migrations
{
    /// <inheritdoc />
    public partial class CreateQuinielas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuinielaDurationId",
                table: "Quinielas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuinielaPickDurationId",
                table: "Quinielas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Quinielas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "ViudaPrice",
                table: "Quinielas",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "QuinielaDuration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    QuinielaTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuinielaDuration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuinielaDuration_QuinielaTypes_QuinielaTypeId",
                        column: x => x.QuinielaTypeId,
                        principalTable: "QuinielaTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuinielaPickDuration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    QuinielaDurationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuinielaPickDuration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuinielaPickDuration_QuinielaDuration_QuinielaDurationId",
                        column: x => x.QuinielaDurationId,
                        principalTable: "QuinielaDuration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "QuinielaTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Participants predict the outcomes of multiple sports matches or races.", "Regular" },
                    { 2, "A survivor-type quiniela involves picking a winner for each round, with elimination upon incorrect predictions until one remains.", "Survivor" },
                    { 3, "A spread-type quiniela requires predicting the point difference (spread) between teams, not just the match winner.", "Spread" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quinielas_QuinielaDurationId",
                table: "Quinielas",
                column: "QuinielaDurationId");

            migrationBuilder.CreateIndex(
                name: "IX_Quinielas_QuinielaPickDurationId",
                table: "Quinielas",
                column: "QuinielaPickDurationId");

            migrationBuilder.CreateIndex(
                name: "IX_Quinielas_StatusId",
                table: "Quinielas",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_QuinielaDuration_QuinielaTypeId",
                table: "QuinielaDuration",
                column: "QuinielaTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_QuinielaPickDuration_QuinielaDurationId",
                table: "QuinielaPickDuration",
                column: "QuinielaDurationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quinielas_QuinielaDuration_QuinielaDurationId",
                table: "Quinielas",
                column: "QuinielaDurationId",
                principalTable: "QuinielaDuration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quinielas_QuinielaPickDuration_QuinielaPickDurationId",
                table: "Quinielas",
                column: "QuinielaPickDurationId",
                principalTable: "QuinielaPickDuration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quinielas_Status_StatusId",
                table: "Quinielas",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quinielas_QuinielaDuration_QuinielaDurationId",
                table: "Quinielas");

            migrationBuilder.DropForeignKey(
                name: "FK_Quinielas_QuinielaPickDuration_QuinielaPickDurationId",
                table: "Quinielas");

            migrationBuilder.DropForeignKey(
                name: "FK_Quinielas_Status_StatusId",
                table: "Quinielas");

            migrationBuilder.DropTable(
                name: "QuinielaPickDuration");

            migrationBuilder.DropTable(
                name: "QuinielaDuration");

            migrationBuilder.DropIndex(
                name: "IX_Quinielas_QuinielaDurationId",
                table: "Quinielas");

            migrationBuilder.DropIndex(
                name: "IX_Quinielas_QuinielaPickDurationId",
                table: "Quinielas");

            migrationBuilder.DropIndex(
                name: "IX_Quinielas_StatusId",
                table: "Quinielas");

            migrationBuilder.DeleteData(
                table: "QuinielaTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "QuinielaTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "QuinielaTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "QuinielaDurationId",
                table: "Quinielas");

            migrationBuilder.DropColumn(
                name: "QuinielaPickDurationId",
                table: "Quinielas");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Quinielas");

            migrationBuilder.DropColumn(
                name: "ViudaPrice",
                table: "Quinielas");
        }
    }
}
