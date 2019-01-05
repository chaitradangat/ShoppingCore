using ShoppingCore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCore.Domain.Products
{
    public class ProductCategory : IEntity
    {
        public int ProductCategoryId { get; set; }

        public string Name { get; set; }
    }
}
