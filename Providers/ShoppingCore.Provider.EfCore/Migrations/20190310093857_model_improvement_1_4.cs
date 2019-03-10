using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCore.Provider.EfCore.Migrations
{
    public partial class model_improvement_1_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Products_ProductID",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_ProductID",
                table: "Addresses");

            migrationBuilder.AddColumn<int>(
                name: "AddressID",
                table: "Products",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AddressID",
                table: "Addresses",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Products_AddressID",
                table: "Addresses",
                column: "AddressID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Products_AddressID",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "AddressID",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "AddressID",
                table: "Addresses",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ProductID",
                table: "Addresses",
                column: "ProductID",
                unique: true,
                filter: "[ProductID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Products_ProductID",
                table: "Addresses",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
