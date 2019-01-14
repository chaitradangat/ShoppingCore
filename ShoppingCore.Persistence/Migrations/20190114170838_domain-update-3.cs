using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCore.Persistence.Migrations
{
    public partial class domainupdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_Products_ProductId",
                table: "ProductCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_ProductCategories_SubCategoryProductCategoryId",
                table: "ProductCategories");

            migrationBuilder.DropIndex(
                name: "IX_ProductCategories_ProductId",
                table: "ProductCategories");

            migrationBuilder.DropIndex(
                name: "IX_ProductCategories_SubCategoryProductCategoryId",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "SubCategoryProductCategoryId",
                table: "ProductCategories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProductCategories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductCategories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubCategoryProductCategoryId",
                table: "ProductCategories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ProductId",
                table: "ProductCategories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_SubCategoryProductCategoryId",
                table: "ProductCategories",
                column: "SubCategoryProductCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_Products_ProductId",
                table: "ProductCategories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_ProductCategories_SubCategoryProductCategoryId",
                table: "ProductCategories",
                column: "SubCategoryProductCategoryId",
                principalTable: "ProductCategories",
                principalColumn: "ProductCategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
