using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCore.Domain.Common;
using ShoppingCore.Domain.Interfaces;

namespace ShoppingCore.Domain.Products
{
    public class ProductImage :IEntity,IProductImage
    {
        public int ProductImageID { get; set; }

        public string ImageUrl { get; set; }

        public Product Product { get; set; }

        public int ProductID { get; set; }
    }
}
