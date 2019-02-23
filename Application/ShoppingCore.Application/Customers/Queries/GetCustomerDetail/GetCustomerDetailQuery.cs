using ShoppingCore.Domain.Common;
using ShoppingCore.Domain.Customers;
using ShoppingCore.Domain.Interfaces;

using ShoppingCore.Application.ApplicationModels;
using ShoppingCore.Application.Interfaces;

using Microsoft.EntityFrameworkCore;


using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ShoppingCore.Application.Customers.Queries.GetCustomerDetail
{
    public class GetCustomerDetailQuery : IGetCustomerDetailQuery
    {
        private readonly IDatabaseService _database;
        private readonly IDomainFactory _factory;

        public GetCustomerDetailQuery(IDatabaseService database, IDomainFactory factory)
        {
            _database = database;
            _factory = factory;
        }

        public IAppModel Execute(int CustomerID)
        {
            var customer = _database.Customers.Include(c => c.Addresses).Include(c => c.User).Where(c => c.CustomerID == CustomerID).FirstOrDefault();


            var x = _database.Include<Customer>(new[] { "User", "Addresses" }).Where(c=>c.CustomerID == 3).FirstOrDefault();






            return ConvertToAppModel(customer);
        }

        private IAppModel ConvertToAppModel(IEntity entity)
        {
            if (! (entity is Customer) )
            {

            }


            if (entity is Customer)
            {
                var customer = entity as Customer;

                var customerModel = new CustomerModel(_factory)
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

                    DateOfBirth = customer.DateOfBirth
                };

                customer.Addresses.ForEach(a => customerModel.Addresses.Add(
                   new AddressModel()
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
                       //CustomerID = a.Customer.CustomerID
                   }));

                return customerModel;
            }
            else
            {
                return null;
            }
        }

    }
}
