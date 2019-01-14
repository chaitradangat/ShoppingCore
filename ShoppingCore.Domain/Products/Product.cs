using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCore.Domain.Common;


namespace ShoppingCore.Domain.Products
{
   public class Product : IEntity
    {
        public int ProductID { get; set; }

        public string Name { get; set; }

        public Units Unit {get;set;}

        public float UnitPrice { get; set; }

        public Address Address { get; set; }

        public string ProductTitle { get; set; }

        public string ProductDescription { get; set; }
    }
}