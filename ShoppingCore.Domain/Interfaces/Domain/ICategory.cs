using System.Collections.Generic;
using ShoppingCore.Domain.Products;

namespace ShoppingCore.Domain.Interfaces
{
    public interface ICategory
    {
         int CategoryID { get; set; }

         string CategoryName { get; set; }

         Category SubCategory { get; set; }

         List<ProductCategory> ProductCategories { get; set; }
    }
}