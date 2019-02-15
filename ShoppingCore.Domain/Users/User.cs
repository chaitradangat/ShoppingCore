using ShoppingCore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCore.Domain.Interfaces;
using ShoppingCore.Domain.Sellers;
using ShoppingCore.Domain.Customers;

namespace ShoppingCore.Domain.Users
{
    public class User : IEntity,IUser
    {
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsAutheticated { get; set; }

        public AutheticationType AutheticationType { get; set; }

        public UserRole UserRole { get; set; }

        public int SellerID { get; set; }

        public Seller Seller { get; set; }


        public int CustomerID { get; set; }

        public Customer Customer { get; set; }

        public User()
        {
            //default user role will be customer
            UserRole = UserRole.Customer;
            Customer = new Customer();
            Seller = null;
        }
    }
}
