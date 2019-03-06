using ShoppingCore.Domain.Common;
using ShoppingCore.Domain.Customers;

using ShoppingCore.Application.Interfaces;
using ShoppingCore.Application.ApplicationModels;
using ShoppingCore.Application.ApplicationModelsMapper;


using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ShoppingCore.Application.Customers.Queries.GetCustomerDetail
{
    public class GetCustomerDetailQuery : IGetCustomerDetailQuery
    {
        private readonly IPersistence<IEntity> _persistence;

        public GetCustomerDetailQuery(IPersistence<IEntity> persistence)
        {
            _persistence = persistence;
        }

        public IQueryable<CustomerModel> Execute()
        {
            return _persistence.Customers.List().MapCustomerModel();
        }

        #region -old code-
        //this code was removed as same operation can be achived now in new method with more flexibility
        //public IAppModel Execute(int CustomerID)
        //{
        //    var customer = _persistence.Customers.Find(CustomerID) as Customer;
        //    return ConvertToAppModel(customer);
        //}
        #endregion

        //this method will be later modified to return List<CustomerModel>
        #region -old code-
        //public IQueryable<Customer> Execute()
        //{
        //    var customers = _persistence.Customers.List();

        //    return customers;
        //}
        #endregion

        //try avoiding this method below
        private IAppModel ConvertToAppModel(IEntity entity)
        {
            if (entity is Customer)
            {
                var customer = entity as Customer;

                var customerModel = new CustomerModel()
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
