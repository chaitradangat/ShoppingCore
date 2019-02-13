using System;
using System.Collections.Generic;
using System.Text;

using ShoppingCore.Domain.Common;

namespace ShoppingCore.Domain.Interfaces
{
    public interface IProduct
    {
        int ProductID { get; set; }

        string Name { get; set; }

        string ProductTitle { get; set; }

        string ProductDescription { get; set; }

        IList<IProductCategory> ProductCategories { get; set; }

        IList<IProductImage> ProductImages { get; set; }

        Units Unit { get; set; }

        string Currency { get; set; }

        float UnitPrice { get; set; }

        ISeller Seller { get; set; }

        int SellerID { get; set; }
    }
}
