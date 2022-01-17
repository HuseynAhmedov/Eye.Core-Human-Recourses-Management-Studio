using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pustok.Migrations
{
    public partial class commentfix11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "comments",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "dateTime",
                table: "comments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "dateTime",
                table: "comments");
        }
    }
}
