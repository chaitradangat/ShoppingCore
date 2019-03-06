using System;
using System.Collections.Generic;
using System.Linq;

using ShoppingCore.Application.ApplicationModels;
using ShoppingCore.Domain.Customers;



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




    }
}
