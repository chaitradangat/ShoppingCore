using ShoppingCore.Domain.Products;
using ShoppingCore.Domain.Common;
using ShoppingCore.Domain.Interfaces;

using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCore.Domain.Users;

namespace ShoppingCore.Domain.Customers
{
    public class Customer : IEntity,ICustomer
    {
        public int CustomerID { get; set; }

        public User User { get; set; }

        //public int UserID { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public List<Address> Addresses { get; set; }

        public Customer()
        {
            Addresses = new List<Address>();
        }
    }
}