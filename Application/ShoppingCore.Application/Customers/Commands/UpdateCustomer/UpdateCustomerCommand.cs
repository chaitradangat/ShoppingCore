using ShoppingCore.Application.Interfaces;
using ShoppingCore.Application.ApplicationModels;
using ShoppingCore.Domain.Customers;
using ShoppingCore.Domain.Common;

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ShoppingCore.Domain.Interfaces;
using ShoppingCore.Domain.Users;

namespace ShoppingCore.Application.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : IUpdateCustomerCommand
    {
        protected readonly IPersistence<IEntity> _persistence;

        protected readonly IDomainFactory _factory;

        public UpdateCustomerCommand(IPersistence<IEntity> persistence, IDomainFactory factory)
        {
            _persistence = persistence;
            _factory = factory;
        }

        public IAppModel Execute(CustomerModel customerModel)
        {
            var customer = ConvertToDomainModel(customerModel) as Customer;

            _persistence.Customers.Update(customer);

            _persistence.Save();

            return customerModel;
        }

        private IEntity ConvertToDomainModel(CustomerModel customerModel)
        {
            var customer = (Customer)_factory.GetEntity<Customer>();

            customer.User = (User)_factory.GetEntity<User>();

            customer.Addresses = new List<Address>();

            //this code dosnt work for disconnected entities pls update later
            



            customer.DateOfBirth = customerModel.DateOfBirth;

            customer.FirstName = customerModel.FirstName;

            customer.MiddleName = customerModel.MiddleName;

            customer.LastName = customerModel.LastName;

            customer.Gender = customerModel.Gender;

            customer.User.UserName = customerModel.UserName;

            customer.User.Password = customerModel.Password;

            customer.User.UserRole = customerModel.UserRole;

            customer.User.IsAutheticated = customerModel.IsAutheticated;

            customer.User.AutheticationType = customerModel.AutheticationType;

            foreach (var address in customerModel.Addresses)
            {
                var a = customer.Addresses.Find(a_ => a_.AddressID == address.AddressID);

                if (a == null)
                {
                    a = (Address)_factory.GetEntity<IAddress>();
                    customer.Addresses.Add(a);
                }

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
                //a.Product = null;
                //a.Customer = customer;
                a.AddressID = address.AddressID;
            }

            if (customer.Addresses.Count > customerModel.Addresses.Count)
            {
                var addIds_ = customerModel.Addresses.Select(a => a.AddressID).ToList();

                foreach (var address in customer.Addresses)
                {
                    if (!addIds_.Contains(address.AddressID))
                        _persistence.Addresses.Delete(address);
                }

                customer.Addresses.RemoveAll(a => !addIds_.Contains(a.AddressID));
            }

            return customer;
        }
    }
}