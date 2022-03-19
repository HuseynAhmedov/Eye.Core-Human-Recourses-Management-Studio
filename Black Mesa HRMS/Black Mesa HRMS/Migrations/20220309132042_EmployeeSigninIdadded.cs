using Microsoft.EntityFrameworkCore.Migrations;

namespace Black_Mesa_HRMS.Migrations
{
    public partial class EmployeeSigninIdadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "signInId",
                table: "Employees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "signInId",
                table: "Employees");
        }
    }
}
