using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ShoppingCore.Application.ApplicationModels;
using ShoppingCore.Application.Interfaces;
using ShoppingCore.Domain.Common;
using ShoppingCore.Domain.Customers;
using ShoppingCore.Domain.Interfaces;
using ShoppingCore.Domain.Users;
using ShoppingCore.Domain.XDomainFactory;


namespace ShoppingCore.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand : ICreateCustomerCommand
    {
        private readonly IDatabaseService _database;
        private readonly IDomainFactory _factory;

        public CreateCustomerCommand(IDatabaseService database,IDomainFactory factory)
        {
            _database = database;
            _factory = factory;
        }

        public IAppModel Execute(CustomerModel customerModel)
        {
            var customer = ConvertToDomainModel(customerModel) as Customer;

            _database.Customers.Add(customer);

            _database.Save();

            return ConvertToAppModel(customer);
        }

        private IEntity ConvertToDomainModel(CustomerModel customerModel)
        {
            var customer = _database.Customers.Find(customerModel.CustomerID);
            var user = _database.Users.Find(customerModel.UserID);

            if (customer == null)
            {
                user = (User)_factory.GetEntity<IUser>();

                customer = (Customer)_factory.GetEntity<ICustomer>();
            }

            user.UserName = customerModel.UserName;

            user.Password = customerModel.Password;

            user.UserRole = customerModel.UserRole;

            user.AutheticationType = customerModel.AutheticationType;

            user.UserID = customerModel.UserID;

            customer.DateOfBirth = customerModel.DateOfBirth;

            customer.FirstName = customerModel.FirstName;

            customer.MiddleName = customerModel.MiddleName;

            customer.LastName = customerModel.LastName;

            customer.Gender = customerModel.Gender;

            customer.User = user;

            customer.CustomerID = customerModel.CustomerID;

            customer.Addresses.Clear();

            foreach (var address in customerModel.Addresses)
            {
                var a = _database.Addresses.Find(address.AddressID);

                if (a == null)
                {
                    a = (Address)_factory.GetEntity<IAddress>();
                    customer.Addresses.Add(a);
                    a.AddressLine1 = address.AddressLine1;
                    a.AddressLine2 = address.AddressLine2;
                    a.AddressLine3 = address.AddressLine3;
                    a.AddressLine4 = address.AddressLine4;
                    a.AddressLine5 = address.AddressLine5;
                    a.AddressType = address.AddressType;
                    a.City = address.City;
                    a.Country = address.Country;
                    a.District = address.District;
                    a.LandMark = address.LandMark;
                    a.PinCode = address.PinCode;
                    a.Product = null;
                    a.Customer = customer;
                    a.AddressID = address.AddressID;
                }
                else
                {
                    throw new Exception("Duplicate Address Fields,Address already exists");
                }
                
            }

            if (customer.Addresses.Count > customerModel.Addresses.Count)
            {
                var addIds_ = customerModel.Addresses.Select(a => a.AddressID).ToList();

                foreach (var address in customer.Addresses)
                {
                    if (!addIds_.Contains(address.AddressID))
                        _database.Addresses.Remove(address);
                }

                customer.Addresses.RemoveAll(a => !addIds_.Contains(a.AddressID));
            }


            return customer;
        }

        private IAppModel ConvertToAppModel(IEntity entity)
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
                   CustomerID = a.Customer.CustomerID
               }));

            return customerModel;
        }

    }
}
