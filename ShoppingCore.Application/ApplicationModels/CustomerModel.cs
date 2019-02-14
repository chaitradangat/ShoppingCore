
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

            //customer.Addresses = Addresses;

            customer.DateOfBirth = DateOfBirth;

            return (Customer)customer;
        }

    }
}
