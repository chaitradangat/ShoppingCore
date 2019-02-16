using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCore.Persistence.Migrations
{
    public partial class usercustsellerfk1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Users_UserID1",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Sellers_Users_UserID1",
                table: "Sellers");

            migrationBuilder.DropIndex(
                name: "IX_Sellers_UserID1",
                table: "Sellers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_UserID1",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "UserID1",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "UserID1",
                table: "Customers");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CustomerID",
                table: "Users",
                column: "CustomerID",
                unique: true,
                filter: "[CustomerID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SellerID",
                table: "Users",
                column: "SellerID",
                unique: true,
                filter: "[SellerID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Customers_CustomerID",
                table: "Users",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Sellers_SellerID",
                table: "Users",
                column: "SellerID",
                principalTable: "Sellers",
                principalColumn: "SellerID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Customers_CustomerID",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Sellers_SellerID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CustomerID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_SellerID",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Sellers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserID1",
                table: "Sellers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserID1",
                table: "Customers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerID",
                keyValue: 1,
                column: "UserID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Sellers",
                keyColumn: "SellerID",
                keyValue: 1,
                column: "UserID",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_UserID1",
                table: "Sellers",
                column: "UserID1");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserID1",
                table: "Customers",
                column: "UserID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Users_UserID1",
                table: "Customers",
                column: "UserID1",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sellers_Users_UserID1",
                table: "Sellers",
                column: "UserID1",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
