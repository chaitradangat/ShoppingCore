
using ShoppingCore.Application.Interfaces;
using ShoppingCore.Domain.Common;
using ShoppingCore.Domain.Customers;
using ShoppingCore.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace ShoppingCore.Application.ApplicationModels
{
    public class CustomerModel : IAppModel
    {
        public int CustomerID { get; set; }

        public int UserID { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public List<AddressModel> Addresses { get; set; }

        private readonly IDomainFactory _factory;

        public CustomerModel(IDomainFactory factory)
        {
            _factory = factory;

            Addresses = new List<AddressModel>();
        }

        public IEntity MorphAppModel()
        {
            return null;
        }

        //this method is violating loose coupling..finding better ways to do this
        public Customer MorphAppModel(IUser user)
        {
            var customer = (ICustomer)_factory.GetEntity<ICustomer>();

            customer.UserID = user.UserID;

            customer.FirstName = FirstName;

            customer.LastName = LastName;

            customer.Gender = Gender;

            customer.MiddleName = MiddleName;

            customer.DateOfBirth = DateOfBirth;

            customer.Addresses = new List<Address>();

            foreach (var address in Addresses)
            {
                var a = (IAddress)_factory.GetEntity<IAddress>();

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
                a.Customer = (Customer)customer;

                customer.Addresses.Add((Address)a);
            }

            return (Customer)customer;
        }

    }
}
