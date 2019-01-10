using ShoppingCore.Domain.Products;
using ShoppingCore.Domain.Common;

using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCore.Domain.Customers
{
    public class Customer : IEntity
    {
        public int CustomerId { get; set; }

        public int UserId { get; set; }

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