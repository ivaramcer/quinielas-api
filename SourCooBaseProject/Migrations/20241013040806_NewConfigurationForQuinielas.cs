using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace QuinielasApi.Migrations
{
    /// <inheritdoc />
    public partial class NewConfigurationForQuinielas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quinielas_QuinielaDuration_QuinielaDurationId",
                table: "Quinielas");

            migrationBuilder.DropForeignKey(
                name: "FK_Quinielas_QuinielaTypes_QuinielaTypeId",
                table: "Quinielas");

            migrationBuilder.DropIndex(
                name: "IX_Quinielas_QuinielaDurationId",
                table: "Quinielas");

            migrationBuilder.DropIndex(
                name: "IX_Quinielas_QuinielaTypeId",
                table: "Quinielas");

            migrationBuilder.DropColumn(
                name: "QuinielaDurationId",
                table: "Quinielas");

            migrationBuilder.DropColumn(
                name: "QuinielaTypeId",
                table: "Quinielas");

            migrationBuilder.AddColumn<string>(
                name: "Round",
                table: "Quinielas",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Week",
                table: "Quinielas",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "QuinielaConfigurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Read = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<double>(type: "double precision", nullable: false),
                    QuinielaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuinielaConfigurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuinielaConfigurations_Quinielas_QuinielaId",
                        column: x => x.QuinielaId,
                        principalTable: "Quinielas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuinielaConfigurations_QuinielaId",
                table: "QuinielaConfigurations",
                column: "QuinielaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuinielaConfigurations");

            migrationBuilder.DropColumn(
                name: "Round",
                table: "Quinielas");

            migrationBuilder.DropColumn(
                name: "Week",
                table: "Quinielas");

            migrationBuilder.AddColumn<int>(
                name: "QuinielaDurationId",
                table: "Quinielas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuinielaTypeId",
                table: "Quinielas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Quinielas_QuinielaDurationId",
                table: "Quinielas",
                column: "QuinielaDurationId");

            migrationBuilder.CreateIndex(
                name: "IX_Quinielas_QuinielaTypeId",
                table: "Quinielas",
                column: "QuinielaTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quinielas_QuinielaDuration_QuinielaDurationId",
                table: "Quinielas",
                column: "QuinielaDurationId",
                principalTable: "QuinielaDuration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quinielas_QuinielaTypes_QuinielaTypeId",
                table: "Quinielas",
                column: "QuinielaTypeId",
                principalTable: "QuinielaTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
