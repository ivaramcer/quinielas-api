using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuinielasApi.Migrations
{
    /// <inheritdoc />
    public partial class WeManipulateBetterThePicks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Deadline",
                table: "UserPicks",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsRegistered",
                table: "UserPicks",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deadline",
                table: "UserPicks");

            migrationBuilder.DropColumn(
                name: "IsRegistered",
                table: "UserPicks");
        }
    }
}
