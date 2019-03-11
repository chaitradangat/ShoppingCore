using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;
using ShoppingCore.Domain.Users;
using ShoppingCore.Domain.Common;
using ShoppingCore.Domain.Customers;
using ShoppingCore.Domain.Sellers;
using ShoppingCore.Domain.Products;

namespace ShoppingCore.Provider.EfCore
{
    public static class SeedDataClass
    {
        public static void SeedAllData(this ModelBuilder modelBuilder)
        {
            SeedUsers(modelBuilder);

            SeedSellers(modelBuilder);

            SeedAddresses(modelBuilder);

            SeedCustomers(modelBuilder);

            SeedCustomerAddresses(modelBuilder);

            SeedProductAddresses(modelBuilder);

            SeedProducts(modelBuilder);

            SeedCategories(modelBuilder);

            SeedProductCategories(modelBuilder);

            SeedProductImages(modelBuilder);
        }

        //first the users are seeded
        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { UserID = 1, UserName = "sam", Password = "samseller", AutheticationType = AutheticationType.AppDatabase, UserRole = UserRole.Seller, CustomerID = null, SellerID = 1 },
                new User { UserID = 2, UserName = "lisa", Password = "lisabuyer", AutheticationType = AutheticationType.AppDatabase, UserRole = UserRole.Customer, CustomerID = 1, SellerID = null }
                );
        }

        //second the sellers are seeded
        public static void SeedSellers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Seller>().HasData(

                new Seller
                {
                    SellerID = 1,
                    BusinessName = "SamuelSales",
                    FirstName = "Samuel",
                    MiddleName = "L",
                    LastName = "Jackson",
                    Gender = "Male",
                    DateOfBirth = DateTime.Parse("1969-01-05"),
                }

                );
        }

        //third the customers are seeded
        public static void SeedCustomers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerID = 1,
                    FirstName = "Lisa",
                    MiddleName = "M",
                    LastName = "Taylor",
                    Gender = "Female",
                    DateOfBirth = DateTime.Parse("1969-04-05"),
                }
                );
        }

        //next the product is seeded
        public static void SeedProducts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(

                new Product
                {
                    ProductID = 1,
                    SellerID = 1,
                    Name = "IPhone",
                    ProductDescription = "A very costly smart phone",
                    ProductTitle = "Iphone X",
                    Unit = Units.Nos,
                    UnitPrice = 1200f,
                    Currency = "USD",
                    ProductAddressID = 1
                }
                );
        }

        //next the product addresses are seeded
        public static void SeedProductAddresses(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductAddress>().HasData(
                new ProductAddress
                {
                    ProductAddressID = 1,
                    AddressID = 2,
                    ProductID = 1
                }
                );
        }


        //next the addresses are seeded
        public static void SeedAddresses(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().HasData(
                new //Address
                {
                    AddressID = 1,
                    AddressLine1 = "Line1",
                    AddressLine2 = "Line2",
                    AddressLine3 = "Line3",
                    AddressLine4 = "Line4",
                    AddressLine5 = "Line5",
                    AddressType = AddressTypeEnum.CustomerAddress,
                    City = "CustomerCity",
                    Country = "CustomerCountry",
                    District = "CustomerDistrict",
                    LandMark = "CustomerLandmark",
                    PinCode = "CustomerPincode",
                },
                new //Address
                {
                    AddressID = 2,
                    AddressLine1 = "Line1",
                    AddressLine2 = "Line2",
                    AddressLine3 = "Line3",
                    AddressLine4 = "Line4",
                    AddressLine5 = "Line5",
                    AddressType = AddressTypeEnum.ProductAddress,
                    City = "ProductCity",
                    Country = "ProductCountry",
                    District = "ProductDistrict",
                    LandMark = "ProductLandmark",
                    PinCode = "ProductPincode",
                    ProductID = 1,
                    CustomerID = (int?)null,
                }
                );
        }

        //next the customer addresses are seeded
        public static void SeedCustomerAddresses(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerAddress>().HasData(
                new CustomerAddress
                {
                    CustomerAddressID = 1,
                    AddressID = 1,
                    CustomerID = 1,
                }
                );
        }

        


        //next the category is seeded
        public static void SeedCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Category1"
                }
                );
        }

        //next the product category is seeded
        public static void SeedProductCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>().HasData(
                new {ProductCategoryID = 1, CategoryID = 1, ProductID = 1 }
                );
        }

        //next the product image is seeded
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
    }
}
