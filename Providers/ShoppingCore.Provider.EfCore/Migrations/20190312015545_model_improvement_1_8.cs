﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCore.Provider.EfCore.Migrations
{
    public partial class model_improvement_1_8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    AddressLine3 = table.Column<string>(nullable: true),
                    AddressLine4 = table.Column<string>(nullable: true),
                    AddressLine5 = table.Column<string>(nullable: true),
                    LandMark = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    PinCode = table.Column<string>(nullable: true),
                    AddressType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(nullable: true),
                    SubCategoryCategoryID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_SubCategoryCategoryID",
                        column: x => x.SubCategoryCategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    SellerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BusinessName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.SellerID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAddresses",
                columns: table => new
                {
                    CustomerAddressID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerID = table.Column<int>(nullable: false),
                    AddressID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAddresses", x => x.CustomerAddressID);
                    table.ForeignKey(
                        name: "FK_CustomerAddresses_Addresses_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Addresses",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerAddresses_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductAddressID = table.Column<int>(nullable: false),
                    SellerID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ProductTitle = table.Column<string>(nullable: true),
                    ProductDescription = table.Column<string>(nullable: true),
                    Unit = table.Column<int>(nullable: false),
                    Currency = table.Column<string>(nullable: true),
                    UnitPrice = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_Sellers_SellerID",
                        column: x => x.SellerID,
                        principalTable: "Sellers",
                        principalColumn: "SellerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(nullable: true),
                    AutheticationType = table.Column<int>(nullable: false),
                    UserRole = table.Column<int>(nullable: false),
                    SellerID = table.Column<int>(nullable: true),
                    CustomerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Sellers_SellerID",
                        column: x => x.SellerID,
                        principalTable: "Sellers",
                        principalColumn: "SellerID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductCategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.ProductCategoryID);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    ProductImageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImageUrl = table.Column<string>(nullable: false),
                    ProductID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.ProductImageID);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressID", "AddressLine1", "AddressLine2", "AddressLine3", "AddressLine4", "AddressLine5", "AddressType", "City", "Country", "District", "LandMark", "PinCode" },
                values: new object[,]
                {
                    { 1, "Line1", "Line2", "Line3", "Line4", "Line5", 8, "CustomerCity", "CustomerCountry", "CustomerDistrict", "CustomerLandmark", "CustomerPincode" },
                    { 2, "Line1", "Line2", "Line3", "Line4", "Line5", 10, "ProductCity", "ProductCountry", "ProductDistrict", "ProductLandmark", "ProductPincode" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName", "SubCategoryCategoryID" },
                values: new object[] { 1, "Category1", null });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "DateOfBirth", "FirstName", "Gender", "LastName", "MiddleName" },
                values: new object[] { 1, new DateTime(1969, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lisa", "Female", "Taylor", "M" });

            migrationBuilder.InsertData(
                table: "Sellers",
                columns: new[] { "SellerID", "BusinessName", "DateOfBirth", "FirstName", "Gender", "LastName", "MiddleName" },
                values: new object[] { 1, "SamuelSales", new DateTime(1969, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samuel", "Male", "Jackson", "L" });

            migrationBuilder.InsertData(
                table: "CustomerAddresses",
                columns: new[] { "CustomerAddressID", "AddressID", "CustomerID" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "Currency", "Name", "ProductAddressID", "ProductDescription", "ProductTitle", "SellerID", "Unit", "UnitPrice" },
                values: new object[] { 1, "USD", "IPhone", 1, "A very costly smart phone", "Iphone X", 1, 4, 1200f });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "AutheticationType", "CustomerID", "Password", "SellerID", "UserName", "UserRole" },
                values: new object[,]
                {
                    { 2, 0, 1, "lisabuyer", null, "lisa", 0 },
                    { 1, 0, null, "samseller", 1, "sam", 1 }
                });

            migrationBuilder.InsertData(
                table: "ProductAddresses",
                columns: new[] { "ProductAddressID", "AddressID", "ProductID" },
                values: new object[] { 1, 2, 1 });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "ProductCategoryID", "CategoryID", "ProductID" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "ProductImageID", "ImageUrl", "ProductID" },
                values: new object[] { 1, "http://someproducturl", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_SubCategoryCategoryID",
                table: "Categories",
                column: "SubCategoryCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddresses_AddressID",
                table: "CustomerAddresses",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddresses_CustomerID",
                table: "CustomerAddresses",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAddresses_AddressID",
                table: "ProductAddresses",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryID",
                table: "ProductCategories",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ProductID",
                table: "ProductCategories",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductID",
                table: "ProductImages",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SellerID",
                table: "Products",
                column: "SellerID");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerAddresses");

            migrationBuilder.DropTable(
                name: "ProductAddresses");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Sellers");
        }
    }
}
