using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCore.Domain.Common;


namespace ShoppingCore.Domain.Products
{
   public class Product : IEntity
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }

        public Units Unit {get;set;}

        public float Quantity { get; set; }

        public float Price { get; set; }

        public Address Address { get; set; }

        public string ProductTitle { get; set; }

        public string ProductDescription { get; set; }
    }
}