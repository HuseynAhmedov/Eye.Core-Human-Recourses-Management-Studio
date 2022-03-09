using Microsoft.EntityFrameworkCore.Migrations;

namespace Black_Mesa_HRMS.Migrations
{
    public partial class NationalityChangeAlphaCodesandNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AlphaCode1",
                table: "Nationalities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AlphaCode2",
                table: "Nationalities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountryCode",
                table: "Nationalities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ShortName",
                table: "Nationalities",
                maxLength: 3,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlphaCode1",
                table: "Nationalities");

            migrationBuilder.DropColumn(
                name: "AlphaCode2",
                table: "Nationalities");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "Nationalities");

            migrationBuilder.DropColumn(
                name: "ShortName",
                table: "Nationalities");
        }
    }
}
