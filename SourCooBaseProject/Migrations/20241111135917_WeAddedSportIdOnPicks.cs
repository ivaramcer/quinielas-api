using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuinielasApi.Migrations
{
    /// <inheritdoc />
    public partial class WeAddedSportIdOnPicks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SportId",
                table: "UserPicks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserPicks_SportId",
                table: "UserPicks",
                column: "SportId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPicks_Sports_SportId",
                table: "UserPicks",
                column: "SportId",
                principalTable: "Sports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPicks_Sports_SportId",
                table: "UserPicks");

            migrationBuilder.DropIndex(
                name: "IX_UserPicks_SportId",
                table: "UserPicks");

            migrationBuilder.DropColumn(
                name: "SportId",
                table: "UserPicks");
        }
    }
}
