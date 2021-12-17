using Microsoft.EntityFrameworkCore.Migrations;

namespace Eterna.Migrations
{
    public partial class AddBlogCreatedTimestamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BackgroudImgSrc",
                table: "sliders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackgroudImgSrc",
                table: "sliders");
        }
    }
}
