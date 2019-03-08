using System;
using System.Collections.Generic;
using System.Linq;


using ShoppingCore.Domain.Common;
using ShoppingCore.Domain.Customers;
using ShoppingCore.Domain.Products;
using ShoppingCore.Application.ApplicationModels;



//special thanks to this article https://www.microsoftpressstore.com/articles/article.aspx?p=2248809&seqNum=2

namespace ShoppingCore.Application.ApplicationModelsMapper
{
    public static class ModelMapper
    {
        public static IQueryable<CustomerModel> MapCustomerModel(this IQueryable<Customer> customers)
        {
            var _customers = customers.Select(customer => new CustomerModel()
            {
                UserID = customer.User.UserID,

                UserName = customer.User.UserName,

                Password = customer.User.Password,

                IsAutheticated = customer.User.IsAutheticated,

                AutheticationType = customer.User.AutheticationType,

                UserRole = customer.User.UserRole,

                CustomerID = customer.CustomerID,

                FirstName = customer.FirstName,

                MiddleName = customer.MiddleName,

                LastName = customer.LastName,

                Gender = customer.Gender,

                DateOfBirth = customer.DateOfBirth,

                Addresses = new List<AddressModel>(customer.Addresses.Select(a => new AddressModel()
                {
                    AddressLine1 = a.AddressLine1,
                    AddressLine2 = a.AddressLine2,
                    AddressLine3 = a.AddressLine3,
                    AddressLine4 = a.AddressLine4,
                    AddressLine5 = a.AddressLine5,
                    AddressType = a.AddressType,
                    City = a.City,
                    Country = a.Country,
                    District = a.District,
                    LandMark = a.LandMark,
                    PinCode = a.PinCode,
                    AddressID = a.AddressID,
                }))
            });

            return _customers;
        }

        public static IQueryable<AddressModel> MapAddressModel(this IQueryable<Address> addresses)
        {
            var _addresses = addresses.Select(address => new AddressModel() {

                AddressLine1 = address.AddressLine1,
                AddressLine2 = address.AddressLine2,
                AddressLine3 = address.AddressLine3,
                AddressLine4 = address.AddressLine4,
                AddressLine5 = address.AddressLine5,
                AddressType = address.AddressType,
                City = address.City,
                Country = address.Country,
                District = address.District,
                LandMark = address.LandMark,
                PinCode = address.PinCode,
                AddressID = address.AddressID,
                CustomerID = address.CustomerID,
                ProductID = address.ProductID
            });

            return _addresses;        
        }

        public static IQueryable<ProductModel> MapProductModel(this IQueryable<Product> products)
        {
            var _products = products.Select(product=> new ProductModel() {

                ProductID = product.ProductID,
                Name = product.Name,
                ProductDescription = product.ProductDescription,
                ProductTitle = product.ProductTitle,
                UnitPrice = product.UnitPrice,
                Currency = product.Currency,
                Seller = new SellerModel() {
                    SellerID = product.Seller.SellerID,
                    UserID = product.Seller.User.UserID,
                    FirstName = product.Seller.FirstName,
                    MiddleName = product.Seller.MiddleName,
                    LastName = product.Seller.LastName,
                    BusinessName = product.Seller.BusinessName,
                    DateOfBirth = product.Seller.DateOfBirth,
                    Gender = product.Seller.Gender,
                    Products = new List<ProductModel>(product.Seller.Products.Select(_product=> new ProductModel() {
                        ProductID = _product.ProductID,
                        Name = _product.Name,
                        ProductDescription = _product.ProductDescription,
                        ProductTitle = _product.ProductTitle,
                        UnitPrice = _product.UnitPrice,
                        Currency = _product.Currency,
                        Unit = _product.Unit,
                        //#pending all properties to be mapped in subproducts on seller,some complicated one's can be ignored
                    }))
                },
                Unit = product.Unit,
                ProductCategories = new List<ProductCategoryModel>(product.ProductCategories.Select(pc=>new ProductCategoryModel() {
                    CategoryModel = new CategoryModel() {
                        CategoryID = pc.Category.CategoryID,
                        CategoryName = pc.Category.CategoryName,
                        SubCategory = new CategoryModel() {
                            CategoryID = pc.Category.SubCategory.CategoryID,
                            CategoryName = pc.Category.SubCategory.CategoryName,
                            //# find efficient way to populate the sub-members skipped for time being
                        }
                    }
                })),
                ProductImages = new List<ProductImageModel>(product.ProductImages.Select(pi=> new ProductImageModel(){
                    ImageUrl = pi.ImageUrl,
                    ProductID = pi.ProductID,
                    ProductImageID = pi.ProductImageID
                })),
            });

            return _products;
        }


    }
}
