using Microsoft.EntityFrameworkCore.Migrations;

namespace Black_Mesa_HRMS.Migrations
{
    public partial class JobPositionAdded102 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_JobPosition_JobPositionId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPosition_Jobs_JobId",
                table: "JobPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPosition_Position_PositionId",
                table: "JobPosition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Position",
                table: "Position");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobPosition",
                table: "JobPosition");

            migrationBuilder.RenameTable(
                name: "Position",
                newName: "Positions");

            migrationBuilder.RenameTable(
                name: "JobPosition",
                newName: "JobPositions");

            migrationBuilder.RenameIndex(
                name: "IX_JobPosition_PositionId",
                table: "JobPositions",
                newName: "IX_JobPositions_PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_JobPosition_JobId",
                table: "JobPositions",
                newName: "IX_JobPositions_JobId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Positions",
                table: "Positions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobPositions",
                table: "JobPositions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_JobPositions_JobPositionId",
                table: "Employees",
                column: "JobPositionId",
                principalTable: "JobPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobPositions_Jobs_JobId",
                table: "JobPositions",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobPositions_Positions_PositionId",
                table: "JobPositions",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_JobPositions_JobPositionId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPositions_Jobs_JobId",
                table: "JobPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPositions_Positions_PositionId",
                table: "JobPositions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Positions",
                table: "Positions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobPositions",
                table: "JobPositions");

            migrationBuilder.RenameTable(
                name: "Positions",
                newName: "Position");

            migrationBuilder.RenameTable(
                name: "JobPositions",
                newName: "JobPosition");

            migrationBuilder.RenameIndex(
                name: "IX_JobPositions_PositionId",
                table: "JobPosition",
                newName: "IX_JobPosition_PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_JobPositions_JobId",
                table: "JobPosition",
                newName: "IX_JobPosition_JobId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Position",
                table: "Position",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobPosition",
                table: "JobPosition",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_JobPosition_JobPositionId",
                table: "Employees",
                column: "JobPositionId",
                principalTable: "JobPosition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosition_Jobs_JobId",
                table: "JobPosition",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosition_Position_PositionId",
                table: "JobPosition",
                column: "PositionId",
                principalTable: "Position",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
