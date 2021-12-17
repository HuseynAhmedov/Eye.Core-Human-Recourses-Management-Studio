using Microsoft.EntityFrameworkCore.Migrations;

namespace Eterna.Migrations
{
    public partial class appItemRowAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContextType",
                table: "appItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContextType",
                table: "appItems");
        }
    }
}
