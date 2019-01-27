﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCore.Domain.Products
{
    public class ProductImage
    {
        public int ProductImageID { get; set; }

        public string ImageUrl { get; set; }

        public Product Product { get; set; }

        public int ProductID { get; set; }
    }
}