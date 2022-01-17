﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Pustok.Migrations
{
    public partial class slideTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "slides",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(nullable: true),
                    HeaderSub = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Price = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_slides", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "slides");
        }
    }
}