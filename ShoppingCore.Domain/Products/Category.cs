using System;
using System.Collections.Generic;
using System.Text;

using ShoppingCore.Domain.Common;
using ShoppingCore.Domain.Interfaces;

namespace ShoppingCore.Domain.Products
{
    public class Category : IEntity,ICategory
    {
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public Category SubCategory { get; set; }
    }
}
