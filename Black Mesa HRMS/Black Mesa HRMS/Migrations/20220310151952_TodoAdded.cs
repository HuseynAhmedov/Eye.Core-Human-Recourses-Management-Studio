using Microsoft.EntityFrameworkCore.Migrations;

namespace Black_Mesa_HRMS.Migrations
{
    public partial class TodoAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Jobs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Jobs");
        }
    }
}
