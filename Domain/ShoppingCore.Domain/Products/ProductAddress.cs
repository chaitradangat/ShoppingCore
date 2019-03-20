using ShoppingCore.Domain.Common;
using ShoppingCore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCore.Domain.Products
{
    public class ProductAddress
    {
        public int ProductAddressID { get; set; }

        public int ProductID { get; set; }

        public int AddressID { get; set; }

        public Product Product { get; set; }

        public Address Address { get; set; }

        public ProductAddress()
        {

        }
    }
}
