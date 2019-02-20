using ShoppingCore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCore.Domain.Interfaces;

namespace ShoppingCore.Domain.Products
{
    public class ProductCategory : IEntity,IProductCategory
    {
        public int ProductCategoryID { get; set; }

        public int CategoryID { get; set; }

        public int ProductID { get; set; }

        public virtual Category Category { get; set; }

        public virtual Product Product { get; set; }
    }
}