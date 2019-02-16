using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCore.Persistence.Migrations
{
    public partial class usercustsellerfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SellerID",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID1",
                table: "Sellers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID1",
                table: "Customers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                column: "SellerID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2,
                column: "CustomerID",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "CustomerID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SellerID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserID1",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "UserID1",
                table: "Customers");
        }
    }
}
