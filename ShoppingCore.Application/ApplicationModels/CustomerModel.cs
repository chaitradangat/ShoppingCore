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

        public Customer _entity;

        #region -Properties required for new customer creation-
        public int? CustomerID { get; set; }

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
        /* Polluting code removed
        

        public IAppModel ConvertToAppModel()
        {
            var customer = _entity;

            UserID = customer.User.UserID;

            UserName = customer.User.UserName;

            Password = customer.User.Password;

            IsAutheticated = customer.User.IsAutheticated;

            AutheticationType = customer.User.AutheticationType;

            UserRole = customer.User.UserRole;

            CustomerID = customer.CustomerID;

            FirstName = customer.FirstName;

            MiddleName = customer.MiddleName;

            LastName = customer.LastName;

            Gender = customer.Gender;

            DateOfBirth = customer.DateOfBirth;

            customer.Addresses.ForEach(a => Addresses.Add(
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

            return this;
        }


        */

    }
}
