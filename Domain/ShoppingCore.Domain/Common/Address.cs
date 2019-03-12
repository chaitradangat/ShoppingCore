using ShoppingCore.Domain.Customers;
using ShoppingCore.Domain.Products;
using ShoppingCore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCore.Domain.Common
{
    public class Address : IEntity,IAddress
    {
        public int AddressID { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        public string AddressLine4 { get; set; }

        public string AddressLine5 { get; set; }

        public string LandMark { get; set; }

        public string City { get; set; }

        public string District { get; set; }

        public string Country { get; set; }

        public string PinCode { get; set; }

        public AddressTypeEnum AddressType { get; set; }

        //public CustomerAddress CustomerAddress { get; set; } #delete cascade not working!
    }
}
