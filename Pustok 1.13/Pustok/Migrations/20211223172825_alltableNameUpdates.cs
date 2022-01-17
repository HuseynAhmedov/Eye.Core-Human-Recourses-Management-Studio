using Microsoft.EntityFrameworkCore.Migrations;

namespace Pustok.Migrations
{
    public partial class alltableNameUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_products_productID",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_productImages_products_productID",
                table: "productImages");

            migrationBuilder.DropForeignKey(
                name: "FK_products_categories_categoryId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_productTags_products_productId",
                table: "productTags");

            migrationBuilder.DropForeignKey(
                name: "FK_productTags_tags_tagId",
                table: "productTags");

            migrationBuilder.DropForeignKey(
                name: "FK_tags_products_ProductId",
                table: "tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tags",
                table: "tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_slides",
                table: "slides");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productTags",
                table: "productTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_products",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productImages",
                table: "productImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_comments",
                table: "comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_categories",
                table: "categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_brands",
                table: "brands");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bottomPromotions",
                table: "bottomPromotions");

            migrationBuilder.RenameTable(
                name: "tags",
                newName: "Tags");

            migrationBuilder.RenameTable(
                name: "slides",
                newName: "Slides");

            migrationBuilder.RenameTable(
                name: "productTags",
                newName: "ProductTags");

            migrationBuilder.RenameTable(
                name: "products",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "productImages",
                newName: "ProductImages");

            migrationBuilder.RenameTable(
                name: "comments",
                newName: "Comments");

            migrationBuilder.RenameTable(
                name: "categories",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "brands",
                newName: "Brands");

            migrationBuilder.RenameTable(
                name: "bottomPromotions",
                newName: "BottomPromotions");

            migrationBuilder.RenameIndex(
                name: "IX_tags_ProductId",
                table: "Tags",
                newName: "IX_Tags_ProductId");

            migrationBuilder.RenameColumn(
                name: "tagId",
                table: "ProductTags",
                newName: "TagId");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "ProductTags",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_productTags_tagId",
                table: "ProductTags",
                newName: "IX_ProductTags_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_productTags_productId",
                table: "ProductTags",
                newName: "IX_ProductTags_ProductId");

            migrationBuilder.RenameColumn(
                name: "categoryId",
                table: "Products",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_products_categoryId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.RenameColumn(
                name: "productID",
                table: "ProductImages",
                newName: "ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_productImages_productID",
                table: "ProductImages",
                newName: "IX_ProductImages_ProductID");

            migrationBuilder.RenameColumn(
                name: "productID",
                table: "Comments",
                newName: "ProductID");

            migrationBuilder.RenameColumn(
                name: "dateTime",
                table: "Comments",
                newName: "DateTime");

            migrationBuilder.RenameIndex(
                name: "IX_comments_productID",
                table: "Comments",
                newName: "IX_Comments_ProductID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Slides",
                table: "Slides",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTags",
                table: "ProductTags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductImages",
                table: "ProductImages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brands",
                table: "Brands",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BottomPromotions",
                table: "BottomPromotions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Products_ProductID",
                table: "Comments",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Products_ProductID",
                table: "ProductImages",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTags_Products_ProductId",
                table: "ProductTags",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTags_Tags_TagId",
                table: "ProductTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Products_ProductId",
                table: "Tags",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Products_ProductID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Products_ProductID",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTags_Products_ProductId",
                table: "ProductTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTags_Tags_TagId",
                table: "ProductTags");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Products_ProductId",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Slides",
                table: "Slides");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTags",
                table: "ProductTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductImages",
                table: "ProductImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brands",
                table: "Brands");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BottomPromotions",
                table: "BottomPromotions");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "tags");

            migrationBuilder.RenameTable(
                name: "Slides",
                newName: "slides");

            migrationBuilder.RenameTable(
                name: "ProductTags",
                newName: "productTags");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "products");

            migrationBuilder.RenameTable(
                name: "ProductImages",
                newName: "productImages");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "comments");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "categories");

            migrationBuilder.RenameTable(
                name: "Brands",
                newName: "brands");

            migrationBuilder.RenameTable(
                name: "BottomPromotions",
                newName: "bottomPromotions");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_ProductId",
                table: "tags",
                newName: "IX_tags_ProductId");

            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "productTags",
                newName: "tagId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "productTags",
                newName: "productId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTags_TagId",
                table: "productTags",
                newName: "IX_productTags_tagId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTags_ProductId",
                table: "productTags",
                newName: "IX_productTags_productId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "products",
                newName: "categoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "products",
                newName: "IX_products_categoryId");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "productImages",
                newName: "productID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductImages_ProductID",
                table: "productImages",
                newName: "IX_productImages_productID");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "comments",
                newName: "productID");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "comments",
                newName: "dateTime");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ProductID",
                table: "comments",
                newName: "IX_comments_productID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tags",
                table: "tags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_slides",
                table: "slides",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productTags",
                table: "productTags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_products",
                table: "products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productImages",
                table: "productImages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_comments",
                table: "comments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_categories",
                table: "categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_brands",
                table: "brands",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bottomPromotions",
                table: "bottomPromotions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_products_productID",
                table: "comments",
                column: "productID",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_productImages_products_productID",
                table: "productImages",
                column: "productID",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_categories_categoryId",
                table: "products",
                column: "categoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_productTags_products_productId",
                table: "productTags",
                column: "productId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_productTags_tags_tagId",
                table: "productTags",
                column: "tagId",
                principalTable: "tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tags_products_ProductId",
                table: "tags",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
