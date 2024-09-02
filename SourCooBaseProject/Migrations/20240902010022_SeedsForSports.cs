using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuinielasApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedsForSports : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Soccer, also known as football, is a team sport where two teams of eleven players compete to score goals by kicking a ball", "Soccer" },
                    { 2, "The NFL (National Football League) is a professional American football league consisting of 32 teams.", "NFL" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
