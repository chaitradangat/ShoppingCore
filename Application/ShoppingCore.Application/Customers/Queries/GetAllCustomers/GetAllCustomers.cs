using ShoppingCore.Application.ApplicationModels;
using ShoppingCore.Application.Interfaces;
using ShoppingCore.Domain.Customers;
using ShoppingCore.Domain.Common;

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace ShoppingCore.Application.Customers.Queries.GetAllCustomers
{
    public class GetAllCustomers : IGetAllCustomers
    {
        IPersistence<IEntity> _persistence;

        public GetAllCustomers(IPersistence<IEntity> persistence)
        {
            _persistence = persistence;
        }

        public IEnumerable<IAppModel> Execute()
        {
            var allCustomers = _persistence.Customers.List();//.ToList();

            foreach (var customer in allCustomers)
            {
                yield return ConvertToAppModel(customer);
            }
        }

        public IEnumerable<T> Execute<T>() where T:IAppModel
        {
            var allCustomers = _persistence.Customers.List();

            foreach (var customer in allCustomers)
            {
                yield return ConvertToAppModel<T>(customer);
            }
        }





        //possible duplication of code
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
                       CustomerID = a.Customer.CustomerID
                   }));

                return customerModel;
            }
            else
            {
                return null;
            }
        }

        private T ConvertToAppModel<T>(IEntity entity) where T:IAppModel
        {
            if (typeof(T) == typeof(CustomerModel))
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
                           CustomerID = a.Customer.CustomerID
                       }));

                    return (T)(object)customerModel;//Convert.ChangeType(customerModel, typeof(T));
                }
                else
                {
                    return default(T);
                }
            }
            else
            {
                return default(T);
            }
        }


    }
}
