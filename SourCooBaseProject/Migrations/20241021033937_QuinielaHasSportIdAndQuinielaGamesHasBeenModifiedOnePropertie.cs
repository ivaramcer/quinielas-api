using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuinielasApi.Migrations
{
    /// <inheritdoc />
    public partial class QuinielaHasSportIdAndQuinielaGamesHasBeenModifiedOnePropertie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SportId",
                table: "Quinielas",
                type: "integer",
                nullable: false,
                defaultValue: 0);
            
            migrationBuilder.Sql(
                "ALTER TABLE \"QuinielaGames\" ALTER COLUMN \"GroupNumber\" TYPE integer USING \"GroupNumber\"::integer;"
            );

            migrationBuilder.AlterColumn<int>(
                name: "GroupNumber",
                table: "QuinielaGames",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quinielas_SportId",
                table: "Quinielas",
                column: "SportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quinielas_Sports_SportId",
                table: "Quinielas",
                column: "SportId",
                principalTable: "Sports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quinielas_Sports_SportId",
                table: "Quinielas");

            migrationBuilder.DropIndex(
                name: "IX_Quinielas_SportId",
                table: "Quinielas");

            migrationBuilder.DropColumn(
                name: "SportId",
                table: "Quinielas");

            migrationBuilder.AlterColumn<string>(
                name: "GroupNumber",
                table: "QuinielaGames",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}
