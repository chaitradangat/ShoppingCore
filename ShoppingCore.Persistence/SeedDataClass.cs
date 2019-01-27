using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;
using ShoppingCore.Domain.Users;
using ShoppingCore.Domain.Common;
using ShoppingCore.Domain.Customers;
using ShoppingCore.Domain.Sellers;
using ShoppingCore.Domain.Products;

namespace ShoppingCore.Persistence
{
    public static class SeedDataClass
    {
        public static void SeedAllData(this ModelBuilder modelBuilder)
        {
            SeedAddresses(modelBuilder);
            SeedCustomers(modelBuilder);
            SeedCategories(modelBuilder);
            SeedSellers(modelBuilder);
            SeedProducts(modelBuilder);
            SeedProductCategories(modelBuilder);
            SeedProductImages(modelBuilder);
            SeedUsers(modelBuilder);
        }

        public static void SeedAddresses(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().HasData(
                new
                {
                    AddressID = 1,
                    AddressLine1 = "Line1",
                    AddressLine2 = "Line2",
                    AddressLine3 = "Line3",
                    AddressLine4 = "Line4",
                    AddressLine5 = "Line5",
                    AddressType = AddressTypeEnum.Residential,
                    City = "CustomerCity",
                    Country = "CustomerCountry",
                    District = "CustomerDistrict",
                    LandMark = "CustomerLandmark",
                    PinCode = "CustomerPincode",
                    CustomerID = 1
                },
                new
                {
                    AddressID = 2,
                    AddressLine1 = "Line1",
                    AddressLine2 = "Line2",
                    AddressLine3 = "Line3",
                    AddressLine4 = "Line4",
                    AddressLine5 = "Line5",
                    AddressType = AddressTypeEnum.Residential,
                    City = "ProductCity",
                    Country = "ProductCountry",
                    District = "ProductDistrict",
                    LandMark = "ProductLandmark",
                    PinCode = "ProductPincode",
                    ProductID = 1
                }
                );
        }

        public static void SeedCustomers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerID = 1,
                    UserID = 2,
                    FirstName = "Lisa",
                    MiddleName = "M",
                    LastName = "Taylor",
                    Gender = "Female",
                    DateOfBirth = DateTime.Parse("1969-04-05")
                }
                );
        }

        public static void SeedCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Category1",
                }
                );
        }

        public static void SeedProducts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(

                new //Product
                {
                    ProductID = 1,
                    SellerID = 1,
                    Name = "IPhone",
                    ProductDescription = "A very costly smart phone",
                    ProductTitle = "Iphone X",
                    Unit = Units.Nos,
                    UnitPrice = 1200f,
                    Currency = "USD",
                }
                );
        }

        public static void SeedProductCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>().HasData(

                new { CategoryID = 1, ProductID = 1 }
                );
        }

        public static void SeedProductImages(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductImage>().HasData(
                new
                {
                    ProductImageID = 1,
                    ProductID = 1,
                    ImageUrl = "http://someproducturl"
                }
                );
        }

        public static void SeedSellers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Seller>().HasData(

                new //Seller
                {
                    SellerID = 1,
                    UserID = 1,
                    BusinessName = "SamuelSales",
                    FirstName = "Samuel",
                    MiddleName = "L",
                    LastName = "Jackson",
                    Gender = "Male",
                    DateOfBirth = DateTime.Parse("1969-01-05")
                }

                );
        }

        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { UserID = 1, UserName = "sam", Password = "samseller", AutheticationType = AutheticationType.AppDatabase },
                new User { UserID = 2, UserName = "lisa", Password = "lisabuyer", AutheticationType = AutheticationType.AppDatabase }
                );
        }
    }
}
