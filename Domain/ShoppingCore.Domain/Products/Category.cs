using ShoppingCore.Domain.Common;
using ShoppingCore.Domain.Interfaces;
using System.Collections.Generic;

namespace ShoppingCore.Domain.Products
{
    public class Category : IEntity,ICategory
    {
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public Category SubCategory { get; set; }

        public virtual List<ProductCategory> ProductCategories { get; set; }
    }
}