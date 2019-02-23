using ShoppingCore.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCore.Domain.Interfaces
{
    public interface IProductCategory
    {
         int CategoryID { get; set; }

         int ProductID { get; set; }

         Category Category { get; set; }

         Product Product { get; set; }
    }
}
