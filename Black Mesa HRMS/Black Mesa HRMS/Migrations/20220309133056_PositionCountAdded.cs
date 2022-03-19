using Microsoft.EntityFrameworkCore.Migrations;

namespace Black_Mesa_HRMS.Migrations
{
    public partial class PositionCountAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostionCount",
                table: "JobPositions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostionCount",
                table: "JobPositions");
        }
    }
}
