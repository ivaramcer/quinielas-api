using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuinielasApi.Migrations
{
    /// <inheritdoc />
    public partial class WeAddedTheExternalIdForGames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExternalId",
                table: "Games",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExternalId",
                table: "Games");
        }
    }
}
