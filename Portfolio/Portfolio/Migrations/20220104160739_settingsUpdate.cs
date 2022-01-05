using Microsoft.EntityFrameworkCore.Migrations;

namespace Portfolio.Migrations
{
    public partial class settingsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_settings",
                table: "settings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_portfolioCards",
                table: "portfolioCards");

            migrationBuilder.RenameTable(
                name: "settings",
                newName: "Settings");

            migrationBuilder.RenameTable(
                name: "portfolioCards",
                newName: "PortfolioCards");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Settings",
                table: "Settings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PortfolioCards",
                table: "PortfolioCards",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Settings",
                table: "Settings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PortfolioCards",
                table: "PortfolioCards");

            migrationBuilder.RenameTable(
                name: "Settings",
                newName: "settings");

            migrationBuilder.RenameTable(
                name: "PortfolioCards",
                newName: "portfolioCards");

            migrationBuilder.AddPrimaryKey(
                name: "PK_settings",
                table: "settings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_portfolioCards",
                table: "portfolioCards",
                column: "Id");
        }
    }
}
