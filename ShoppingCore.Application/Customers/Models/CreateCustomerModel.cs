using ShoppingCore.Domain.Common;
using ShoppingCore.Domain.Customers;
using ShoppingCore.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCore.Application.Customers.Models
{
    public class CreateCustomerModel
    {
        public int CustomerID { get; set; }

        public int UserID { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public List<Address> Addresses { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsAutheticated { get; set; }

        public AutheticationType AutheticationType { get; set; }

        public UserRole UserRole { get; set; }

        public CreateCustomerModel()
        {
            //default user role will be customer
            UserRole = UserRole.Customer;

            Addresses = new List<Address>();
        }

        public void MorphModel(ref User user,ref Customer customer)
        {
            user = new User { UserName = UserName, Password = Password, UserRole = UserRole, AutheticationType = AutheticationType };

            customer = new Customer
            {
                FirstName = FirstName,
                MiddleName = MiddleName,
                LastName =  LastName,
                Gender = Gender,
                DateOfBirth = DateOfBirth,
                Addresses = Addresses
            };
        }





    }
}
