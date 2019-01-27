using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCore.Domain.Common;
using ShoppingCore.Domain.Sellers;

namespace ShoppingCore.Domain.Products
{
   public class Product : IEntity
    {
        public int ProductID { get; set; }

        public string Name { get; set; }

        public string ProductTitle { get; set; }

        public string ProductDescription { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }

        public List<ProductImage> ProductImages { get; set; }

        public Units Unit {get;set;}

        public string Currency { get; set; }

        public float UnitPrice { get; set; }


        //public int AddressID { get; set; }

        //public Address Address { get; set; }

        
        public Seller Seller { get; set;}

        public int SellerID { get; set; }

        
        public Product()
        {
            ProductCategories = new List<ProductCategory>();
            ProductImages = new List<ProductImage>();
        }
    }
}