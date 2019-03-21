using System;
using System.Collections.Generic;
using System.Linq;

using ShoppingCore.Domain.Users;
using ShoppingCore.Domain.Interfaces;
using ShoppingCore.Domain.Customers;
using ShoppingCore.Domain.Products;
using ShoppingCore.Application.ApplicationModels;
using ShoppingCore.Application.Interfaces;
using ShoppingCore.Domain.Common;



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

                Addresses = customer.Addresses.Select(a => new CustomerAddressModel()
                {
                    AddressLine1 = a.Address.AddressLine1,
                    AddressLine2 = a.Address.AddressLine2,
                    AddressLine3 = a.Address.AddressLine3,
                    AddressLine4 = a.Address.AddressLine4,
                    AddressLine5 = a.Address.AddressLine5,
                    AddressType = a.Address.AddressType,
                    City = a.Address.City,
                    Country = a.Address.Country,
                    District = a.Address.District,
                    LandMark = a.Address.LandMark,
                    PinCode = a.Address.PinCode,
                    CustomerAddressID = a.CustomerAddressID,
                    AddressID = a.AddressID,
                    CustomerID = a.CustomerID
                }) as ICollection<CustomerAddressModel>
            });

            return _customers;
        }

        public static IQueryable<AddressModel> MapAddressModel(this IQueryable<Address> addresses)
        {
            var _addresses = addresses.Select(address => new AddressModel()
            {

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
            });

            return _addresses;
        }

        //public static IQueryable<ProductModel> MapProductModel(this IQueryable<Product> products)
        //{
        //    var _products = products.Select(product => new ProductModel()
        //    {

        //        ProductID = product.ProductID,
        //        Name = product.Name,
        //        ProductDescription = product.ProductDescription,
        //        ProductTitle = product.ProductTitle,
        //        UnitPrice = product.UnitPrice,
        //        Currency = product.Currency,
        //        Seller = new SellerModel()
        //        {
        //            SellerID = product.Seller.SellerID,
        //            UserID = product.Seller.User.UserID,
        //            FirstName = product.Seller.FirstName,
        //            MiddleName = product.Seller.MiddleName,
        //            LastName = product.Seller.LastName,
        //            DateOfBirth = product.Seller.DateOfBirth,
        //            Gender = product.Seller.Gender,

        //            Products = new List<ProductModel>(product.Seller.Products.Select(_product => new ProductModel()
        //            {
        //                ProductID = _product.ProductID,
        //                Name = _product.Name,
        //                ProductDescription = _product.ProductDescription,
        //                ProductTitle = _product.ProductTitle,
        //                UnitPrice = _product.UnitPrice,
        //                Currency = _product.Currency,
        //                Unit = _product.Unit,
        //                //#pending all properties to be mapped in subproducts on seller,some complicated one's can be ignored
        //            }))
        //        },
        //        Unit = product.Unit,
        //        ProductCategories = new List<ProductCategoryModel>(product.ProductCategories.Select(pc => new ProductCategoryModel()
        //        {
        //            CategoryModel = new CategoryModel()
        //            {
        //                CategoryID = pc.Category.CategoryID,
        //                CategoryName = pc.Category.CategoryName,
        //                SubCategory = new CategoryModel()
        //                {
        //                    CategoryID = pc.Category.SubCategory.CategoryID,
        //                    CategoryName = pc.Category.SubCategory.CategoryName,
        //                    //# find efficient way to populate the sub-members skipped for time being
        //                }
        //            }
        //        })),
        //        ProductImages = new List<ProductImageModel>(product.ProductImages.Select(pi => new ProductImageModel()
        //        {
        //            ImageUrl = pi.ImageUrl,
        //            ProductID = pi.ProductID,
        //            ProductImageID = pi.ProductImageID
        //        })),
        //    });

        //    return _products;
        //}

        public static IQueryable<UserModel> MapUserModel(this IQueryable<User> users)
        {
            return
            users.Select(u => new UserModel{

                UserID = u.UserID,

                CustomerID = u.CustomerID,

                SellerID = u.SellerID,

                UserName = u.UserName,

                Password = u.Password,

                UserRole = u.UserRole,

                AutheticationType = u.AutheticationType,
            });

        }

        public static IAppModel MapEntityToAppModel(this IEntity entity)
        {
            if (entity is null)
            {
                return null;
            }

            //for mapping user domain entity
            if (entity.GetType() == typeof(User))
            {
                var u = entity as User;

                var appModel = new UserModel
                {

                    UserID = u.UserID,

                    CustomerID = u.CustomerID,

                    SellerID = u.SellerID,

                    UserName = u.UserName,

                    Password = u.Password,

                    AutheticationType = u.AutheticationType,

                    UserRole = u.UserRole,

                    IsAutheticated = u.IsAutheticated,

                    /*
                     #pitfall: this mapping does not map the navigation property 
                     as the appmodel does not have a navigation property to avoid 
                     complicated un-natural code,extra db call required for
                     fetching Customer/Seller Entity
                     */
                };

                return appModel;
            }
            else
            {
                throw new NotImplementedException();
            }


        }
    }
}
