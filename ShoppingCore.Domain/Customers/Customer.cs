using ShoppingCore.Domain.Products;
using ShoppingCore.Domain.Common;

using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCore.Domain.Customers
{
    public class Customer : IEntity
    {
        public int Id { get; set; }

        public Customer()
        {
            Product p = new Product { Units = Units.Unit };
        }
    }
}