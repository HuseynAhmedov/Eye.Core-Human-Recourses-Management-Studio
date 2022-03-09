using Microsoft.EntityFrameworkCore.Migrations;

namespace Black_Mesa_HRMS.Migrations
{
    public partial class EmployeeNationalityChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "NationalityID",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_NationalityID",
                table: "Employees",
                column: "NationalityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Nationalities_NationalityID",
                table: "Employees",
                column: "NationalityID",
                principalTable: "Nationalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Nationalities_NationalityID",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_NationalityID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "NationalityID",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "Nationality",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
