using Microsoft.EntityFrameworkCore.Migrations;

namespace Pustok.Migrations
{
    public partial class OrderTableChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CodeNumber",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CodePrefix",
                table: "Orders",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Orders",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodeNumber",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CodePrefix",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Orders");
        }
    }
}
