using System;
using System.Collections.Generic;
using System.Text;

using ShoppingCore.Domain.Common;

namespace ShoppingCore.Domain.Products
{
    public class Category : IEntity
    {
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public Category SubCategory { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
    }
}
