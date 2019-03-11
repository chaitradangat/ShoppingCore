using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCore.Provider.EfCore.Migrations
{
    public partial class model_improvement_1_8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Addresses_AddressID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_AddressID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_CustomerAddresses_AddressID",
                table: "CustomerAddresses");

            migrationBuilder.DropColumn(
                name: "AddressID",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductAddressID",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProductAddresses",
                columns: table => new
                {
                    ProductAddressID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    AddressID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAddresses", x => x.ProductAddressID);
                    table.ForeignKey(
                        name: "FK_ProductAddresses_Addresses_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Addresses",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductAddresses_Products_ProductAddressID",
                        column: x => x.ProductAddressID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductAddresses",
                columns: new[] { "ProductAddressID", "AddressID", "ProductID" },
                values: new object[] { 1, 2, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1,
                column: "ProductAddressID",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddresses_AddressID",
                table: "CustomerAddresses",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAddresses_AddressID",
                table: "ProductAddresses",
                column: "AddressID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductAddresses");

            migrationBuilder.DropIndex(
                name: "IX_CustomerAddresses_AddressID",
                table: "CustomerAddresses");

            migrationBuilder.DropColumn(
                name: "ProductAddressID",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "AddressID",
                table: "Products",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1,
                column: "AddressID",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Products_AddressID",
                table: "Products",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddresses_AddressID",
                table: "CustomerAddresses",
                column: "AddressID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Addresses_AddressID",
                table: "Products",
                column: "AddressID",
                principalTable: "Addresses",
                principalColumn: "AddressID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
