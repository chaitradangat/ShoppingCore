using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCore.Persistence.Migrations
{
    public partial class manytomanycategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories");

            migrationBuilder.DropIndex(
                name: "IX_ProductCategories_CategoryID",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "ProductCategoryID",
                table: "ProductCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories",
                columns: new[] { "CategoryID", "ProductID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories");

            migrationBuilder.AddColumn<int>(
                name: "ProductCategoryID",
                table: "ProductCategories",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories",
                column: "ProductCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryID",
                table: "ProductCategories",
                column: "CategoryID");
        }
    }
}
