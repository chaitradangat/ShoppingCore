using ShoppingCore.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCore.Domain.Interfaces
{
    public interface IProductImage
    {
         int ProductImageID { get; set; }

         string ImageUrl { get; set; }

         Product Product { get; set; }

         int ProductID { get; set; }
    }
}
