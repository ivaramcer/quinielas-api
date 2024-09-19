using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuinielasApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedersForTheDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "QuinielaDuration",
                columns: new[] { "Id", "Description", "Name", "QuinielaTypeId" },
                values: new object[,]
                {
                    { 1, "Participants predict outcomes for that specific set of matches or events.", "Round", 1 },
                    { 2, "Participants predicting outcomes across multiple rounds or events throughout the season.", "Season", 1 },
                    { 3, "Allows participants to choose specific matches.", "Custom", 1 },
                    { 4, "Participants predicting outcomes across multiple rounds or events throughout the season.", "Season", 2 },
                    { 5, "Participants predict outcomes for that specific set of matches or events.", "Round", 3 },
                    { 6, "Participants predicting outcomes across multiple rounds or events throughout the season.", "Season", 3 },
                    { 7, "Allows participants to choose specific matches.", "Custom", 3 }
                });

            migrationBuilder.InsertData(
                table: "QuinielaPickDuration",
                columns: new[] { "Id", "Name", "QuinielaDurationId", "Value" },
                values: new object[,]
                {
                    { 1, "Before first game", 1, "beforeFirst" },
                    { 2, "Before each game", 1, "beforeEach" },
                    { 3, "Before first game", 2, "beforeFirst" },
                    { 4, "Before each game", 2, "beforeEach" },
                    { 5, "Before first game", 3, "beforeFirst" },
                    { 6, "Before each game", 3, "beforeEach" },
                    { 7, "First", 4, "viudaOne" },
                    { 8, "Second", 4, "viudaTwo" },
                    { 9, "Third", 4, "viudaThree" },
                    { 10, "Fourth", 4, "viudaFour" },
                    { 11, "Fifth", 4, "viudaFive" },
                    { 12, "Sixth", 4, "viudaSix" },
                    { 13, "Seventh", 4, "viudaSeven" },
                    { 14, "Eighth", 4, "viudaEight" },
                    { 15, "Ninth", 4, "viudaNine" },
                    { 16, "Tenth", 4, "viudaTen" },
                    { 17, "Eleventh", 4, "viudaEleven" },
                    { 18, "Twelfth", 4, "viudaTwelve" },
                    { 19, "Thirteenth", 4, "viudaThirteen" },
                    { 20, "Fourteenth", 4, "viudaFourteen" },
                    { 21, "Fifteenth", 4, "viudaFifteen" },
                    { 22, "Sixteenth", 4, "viudaSixteen" },
                    { 23, "Seventeenth", 4, "viudaSeventeen" },
                    { 24, "Eighteenth", 4, "viudaEighteen" },
                    { 25, "Nineteenth", 4, "viudaNineteen" },
                    { 26, "Twentieth", 4, "viudaTwenty" },
                    { 27, "Before first game", 5, "beforeFirst" },
                    { 28, "Before each game", 5, "beforeEach" },
                    { 29, "Before first game", 6, "beforeFirst" },
                    { 30, "Before each game", 6, "beforeEach" },
                    { 31, "Before first game", 7, "beforeFirst" },
                    { 32, "Before each game", 7, "beforeEach" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "QuinielaPickDuration",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "QuinielaPickDuration",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "QuinielaPickDuration",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "QuinielaPickDuration",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "QuinielaPickDuration",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "QuinielaPickDuration",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "QuinielaPickDuration",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "QuinielaPickDuration",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "QuinielaPickDuration",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "QuinielaPickDuration",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "QuinielaPickDuration",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "QuinielaPickDuration",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "QuinielaPickDuration",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "QuinielaPickDuration",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "QuinielaPickDuration",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "QuinielaPickDuration",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "QuinielaPickDuration",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "QuinielaPickDuration",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "QuinielaPickDuration",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "QuinielaPickDuration",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "QuinielaPickDuration",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "QuinielaPickDuration",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "QuinielaPickDuration",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "QuinielaPickDuration",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "QuinielaPickDuration",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "QuinielaPickDuration",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "QuinielaPickDuration",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "QuinielaPickDuration",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "QuinielaPickDuration",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "QuinielaPickDuration",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "QuinielaPickDuration",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "QuinielaPickDuration",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "QuinielaDuration",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "QuinielaDuration",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "QuinielaDuration",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "QuinielaDuration",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "QuinielaDuration",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "QuinielaDuration",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "QuinielaDuration",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
