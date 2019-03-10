using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCore.Provider.EfCore.Migrations
{
    public partial class model_improvement_1_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Products_ProductID",
                table: "Addresses");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Products_ProductID",
                table: "Addresses",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Products_ProductID",
                table: "Addresses");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Products_ProductID",
                table: "Addresses",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
