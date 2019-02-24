﻿using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCore.Domain.Common;
using ShoppingCore.Domain.Sellers;
using ShoppingCore.Domain.Interfaces;

namespace ShoppingCore.Domain.Products
{
   public class Product : IEntity,IProduct
    {
        public int? ProductID { get; set; }

        public string Name { get; set; }

        public string ProductTitle { get; set; }

        public string ProductDescription { get; set; }

        public Units Unit {get;set;}

        public string Currency { get; set; }

        public float UnitPrice { get; set; }


        public virtual List<ProductCategory> ProductCategories { get; set; }

        public virtual List<ProductImage> ProductImages { get; set; }

        public virtual Address Address { get; set; }

        public virtual Seller Seller { get; set;}

        public int SellerID { get; set; }

        
        public Product()
        {
            ProductCategories = new List<ProductCategory>();
            ProductImages = new List<ProductImage>();
        }
    }
}