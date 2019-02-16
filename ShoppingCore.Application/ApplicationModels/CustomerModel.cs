using ShoppingCore.Application.Interfaces;
using ShoppingCore.Domain.Common;
using ShoppingCore.Domain.Customers;
using ShoppingCore.Domain.Interfaces;
using ShoppingCore.Domain.Users;
using System;
using System.Collections.Generic;

namespace ShoppingCore.Application.ApplicationModels
{
    public class CustomerModel : IAppModel
    {
        private readonly IDomainFactory _factory;

        #region -Properties required for new customer creation-
        public int CustomerID { get; set; }

        public int UserID { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public List<AddressModel> Addresses { get; set; }
        #endregion

        #region -Properties required for new user creation-

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsAutheticated { get; set; }

        public AutheticationType AutheticationType { get; set; }

        public UserRole UserRole { get; set; }

        #endregion


        public CustomerModel(IDomainFactory factory)
        {
            _factory = factory;

            Addresses = new List<AddressModel>();
        }

        //this method is violating loose coupling..finding better ways to do this
        public IEntity MorphAppModel()
        {
            var user = (User)_factory.GetEntity<IUser>();
            user.UserName = UserName;
            user.Password = Password;
            user.UserRole = UserRole;
            user.AutheticationType = AutheticationType;


            var customer = (Customer)_factory.GetEntity<ICustomer>();

            customer.DateOfBirth = DateOfBirth;

            customer.FirstName = FirstName;

            customer.MiddleName = MiddleName;

            customer.LastName = LastName;

            customer.Gender = Gender;

            customer.User = user;


            foreach (var address in Addresses)
            {
                var a = (Address)_factory.GetEntity<IAddress>();

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

                customer.Addresses.Add(a);
            }







            return customer;

        }

    }
}
