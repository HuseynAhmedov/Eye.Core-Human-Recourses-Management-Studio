using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pustok.Migrations
{
    public partial class CommentChanges101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Comments",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Comments",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeAdded",
                table: "Comments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AppUserId",
                table: "Comments",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_AppUserId",
                table: "Comments",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_AppUserId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AppUserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "TimeAdded",
                table: "Comments");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
