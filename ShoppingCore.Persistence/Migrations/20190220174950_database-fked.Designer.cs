﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoppingCore.Persistence;

namespace ShoppingCore.Persistence.Migrations
{
    [DbContext(typeof(ShoppingCoreDbContext))]
    [Migration("20190220174950_database-fked")]
    partial class databasefked
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShoppingCore.Domain.Common.Address", b =>
                {
                    b.Property<int>("AddressID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLine1");

                    b.Property<string>("AddressLine2");

                    b.Property<string>("AddressLine3");

                    b.Property<string>("AddressLine4");

                    b.Property<string>("AddressLine5");

                    b.Property<int>("AddressType");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<int?>("CustomerID");

                    b.Property<string>("District");

                    b.Property<string>("LandMark");

                    b.Property<string>("PinCode");

                    b.Property<int?>("ProductID");

                    b.HasKey("AddressID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("ProductID")
                        .IsUnique()
                        .HasFilter("[ProductID] IS NOT NULL");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            AddressID = 1,
                            AddressLine1 = "Line1",
                            AddressLine2 = "Line2",
                            AddressLine3 = "Line3",
                            AddressLine4 = "Line4",
                            AddressLine5 = "Line5",
                            AddressType = 0,
                            City = "CustomerCity",
                            Country = "CustomerCountry",
                            CustomerID = 1,
                            District = "CustomerDistrict",
                            LandMark = "CustomerLandmark",
                            PinCode = "CustomerPincode"
                        },
                        new
                        {
                            AddressID = 2,
                            AddressLine1 = "Line1",
                            AddressLine2 = "Line2",
                            AddressLine3 = "Line3",
                            AddressLine4 = "Line4",
                            AddressLine5 = "Line5",
                            AddressType = 0,
                            City = "ProductCity",
                            Country = "ProductCountry",
                            District = "ProductDistrict",
                            LandMark = "ProductLandmark",
                            PinCode = "ProductPincode",
                            ProductID = 1
                        });
                });

            modelBuilder.Entity("ShoppingCore.Domain.Customers.Customer", b =>
                {
                    b.Property<int?>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateOfBirth");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender");

                    b.Property<string>("LastName");

                    b.Property<string>("MiddleName");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerID = 1,
                            DateOfBirth = new DateTime(1969, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Lisa",
                            Gender = "Female",
                            LastName = "Taylor",
                            MiddleName = "M"
                        });
                });

            modelBuilder.Entity("ShoppingCore.Domain.Products.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName");

                    b.Property<int?>("SubCategoryCategoryID");

                    b.HasKey("CategoryID");

                    b.HasIndex("SubCategoryCategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            CategoryName = "Category1"
                        });
                });

            modelBuilder.Entity("ShoppingCore.Domain.Products.Product", b =>
                {
                    b.Property<int?>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Currency");

                    b.Property<string>("Name");

                    b.Property<string>("ProductDescription");

                    b.Property<string>("ProductTitle");

                    b.Property<int>("SellerID");

                    b.Property<int>("Unit");

                    b.Property<float>("UnitPrice");

                    b.HasKey("ProductID");

                    b.HasIndex("SellerID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductID = 1,
                            Currency = "USD",
                            Name = "IPhone",
                            ProductDescription = "A very costly smart phone",
                            ProductTitle = "Iphone X",
                            SellerID = 1,
                            Unit = 4,
                            UnitPrice = 1200f
                        });
                });

            modelBuilder.Entity("ShoppingCore.Domain.Products.ProductCategory", b =>
                {
                    b.Property<int>("ProductCategoryID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryID");

                    b.Property<int>("ProductID");

                    b.HasKey("ProductCategoryID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("ProductID");

                    b.ToTable("ProductCategories");

                    b.HasData(
                        new
                        {
                            ProductCategoryID = 1,
                            CategoryID = 1,
                            ProductID = 1
                        });
                });

            modelBuilder.Entity("ShoppingCore.Domain.Products.ProductImage", b =>
                {
                    b.Property<int>("ProductImageID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl")
                        .IsRequired();

                    b.Property<int>("ProductID");

                    b.HasKey("ProductImageID");

                    b.HasIndex("ProductID");

                    b.ToTable("ProductImages");

                    b.HasData(
                        new
                        {
                            ProductImageID = 1,
                            ImageUrl = "http://someproducturl",
                            ProductID = 1
                        });
                });

            modelBuilder.Entity("ShoppingCore.Domain.Sellers.Seller", b =>
                {
                    b.Property<int>("SellerID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BusinessName");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender");

                    b.Property<string>("LastName");

                    b.Property<string>("MiddleName");

                    b.HasKey("SellerID");

                    b.ToTable("Sellers");

                    b.HasData(
                        new
                        {
                            SellerID = 1,
                            BusinessName = "SamuelSales",
                            DateOfBirth = new DateTime(1969, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Samuel",
                            Gender = "Male",
                            LastName = "Jackson",
                            MiddleName = "L"
                        });
                });

            modelBuilder.Entity("ShoppingCore.Domain.Users.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AutheticationType");

                    b.Property<int?>("CustomerID");

                    b.Property<string>("Password");

                    b.Property<int?>("SellerID");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("UserRole");

                    b.HasKey("UserID");

                    b.HasIndex("CustomerID")
                        .IsUnique()
                        .HasFilter("[CustomerID] IS NOT NULL");

                    b.HasIndex("SellerID")
                        .IsUnique()
                        .HasFilter("[SellerID] IS NOT NULL");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            AutheticationType = 0,
                            Password = "samseller",
                            SellerID = 1,
                            UserName = "sam",
                            UserRole = 1
                        },
                        new
                        {
                            UserID = 2,
                            AutheticationType = 0,
                            CustomerID = 1,
                            Password = "lisabuyer",
                            UserName = "lisa",
                            UserRole = 0
                        });
                });

            modelBuilder.Entity("ShoppingCore.Domain.Common.Address", b =>
                {
                    b.HasOne("ShoppingCore.Domain.Customers.Customer")
                        .WithMany("Addresses")
                        .HasForeignKey("CustomerID");

                    b.HasOne("ShoppingCore.Domain.Products.Product")
                        .WithOne("Address")
                        .HasForeignKey("ShoppingCore.Domain.Common.Address", "ProductID");
                });

            modelBuilder.Entity("ShoppingCore.Domain.Products.Category", b =>
                {
                    b.HasOne("ShoppingCore.Domain.Products.Category", "SubCategory")
                        .WithMany()
                        .HasForeignKey("SubCategoryCategoryID");
                });

            modelBuilder.Entity("ShoppingCore.Domain.Products.Product", b =>
                {
                    b.HasOne("ShoppingCore.Domain.Sellers.Seller", "Seller")
                        .WithMany("Products")
                        .HasForeignKey("SellerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShoppingCore.Domain.Products.ProductCategory", b =>
                {
                    b.HasOne("ShoppingCore.Domain.Products.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShoppingCore.Domain.Products.Product", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShoppingCore.Domain.Products.ProductImage", b =>
                {
                    b.HasOne("ShoppingCore.Domain.Products.Product", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShoppingCore.Domain.Users.User", b =>
                {
                    b.HasOne("ShoppingCore.Domain.Customers.Customer")
                        .WithOne("User")
                        .HasForeignKey("ShoppingCore.Domain.Users.User", "CustomerID");

                    b.HasOne("ShoppingCore.Domain.Sellers.Seller")
                        .WithOne("User")
                        .HasForeignKey("ShoppingCore.Domain.Users.User", "SellerID");
                });
#pragma warning restore 612, 618
        }
    }
}
