﻿using ShoppingCore.Domain.Common;
using ShoppingCore.Domain.Interfaces;
using ShoppingCore.Domain.Users;
using ShoppingCore.Domain.Products;

using System;
using System.Collections.Generic;
using System.Text;


namespace ShoppingCore.Domain.Customers
{
    public class Customer : IEntity,ICustomer
    {
        public int? CustomerID { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public virtual User User { get; set; }

        public virtual List<Address> Addresses { get; set; }

        public Customer()
        {
            Addresses = new List<Address>();
        }
    }
}