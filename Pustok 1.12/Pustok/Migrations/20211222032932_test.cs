using Microsoft.EntityFrameworkCore.Migrations;

namespace Pustok.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "tags",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tags_ProductId",
                table: "tags",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_tags_products_ProductId",
                table: "tags",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tags_products_ProductId",
                table: "tags");

            migrationBuilder.DropIndex(
                name: "IX_tags_ProductId",
                table: "tags");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "tags");
        }
    }
}
