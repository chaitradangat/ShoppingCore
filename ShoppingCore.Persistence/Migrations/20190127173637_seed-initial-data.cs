using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCore.Persistence.Migrations
{
    public partial class seedinitialdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Products_ProductID",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Addresses_AddressID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_AddressID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AddressID",
                table: "Products");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Sellers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Sellers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Sellers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Sellers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "Sellers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Products",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "ProductImages",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "Addresses",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName", "SubCategoryCategoryID" },
                values: new object[] { 1, "Category1", null });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "DateOfBirth", "FirstName", "Gender", "LastName", "MiddleName", "UserID" },
                values: new object[] { 1, new DateTime(1969, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lisa", "Female", "Taylor", "M", 2 });

            migrationBuilder.InsertData(
                table: "Sellers",
                columns: new[] { "SellerID", "BusinessName", "DateOfBirth", "FirstName", "Gender", "LastName", "MiddleName", "UserID" },
                values: new object[] { 1, "SamuelSales", new DateTime(1969, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samuel", "Male", "Jackson", "L", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "AutheticationType", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "samseller", "sam" },
                    { 2, 0, "lisabuyer", "lisa" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressID", "AddressLine1", "AddressLine2", "AddressLine3", "AddressLine4", "AddressLine5", "AddressType", "City", "Country", "CustomerID", "District", "LandMark", "PinCode", "ProductID" },
                values: new object[] { 1, "Line1", "Line2", "Line3", "Line4", "Line5", 0, "CustomerCity", "CustomerCountry", 1, "CustomerDistrict", "CustomerLandmark", "CustomerPincode", null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "Currency", "Name", "ProductDescription", "ProductTitle", "SellerID", "Unit", "UnitPrice" },
                values: new object[] { 1, "USD", "IPhone", "A very costly smart phone", "Iphone X", 1, 4, 1200f });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressID", "AddressLine1", "AddressLine2", "AddressLine3", "AddressLine4", "AddressLine5", "AddressType", "City", "Country", "CustomerID", "District", "LandMark", "PinCode", "ProductID" },
                values: new object[] { 2, "Line1", "Line2", "Line3", "Line4", "Line5", 0, "ProductCity", "ProductCountry", null, "ProductDistrict", "ProductLandmark", "ProductPincode", 1 });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "CategoryID", "ProductID" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "ProductImageID", "ImageUrl", "ProductID" },
                values: new object[] { 1, "http://someproducturl", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ProductID",
                table: "Addresses",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Products_ProductID",
                table: "Addresses",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Products_ProductID",
                table: "ProductImages",
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

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Products_ProductID",
                table: "ProductImages");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_ProductID",
                table: "Addresses");

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryID", "ProductID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sellers",
                keyColumn: "SellerID",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "Addresses");

            migrationBuilder.AddColumn<int>(
                name: "AddressID",
                table: "Products",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "ProductImages",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Products_AddressID",
                table: "Products",
                column: "AddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Products_ProductID",
                table: "ProductImages",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Restrict);

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
