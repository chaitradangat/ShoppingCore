using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCore.Domain.Interfaces
{
    public interface IProductCategory
    {
         int CategoryID { get; set; }

         int ProductID { get; set; }

         ICategory Category { get; set; }

         IProduct Product { get; set; }
    }
}
