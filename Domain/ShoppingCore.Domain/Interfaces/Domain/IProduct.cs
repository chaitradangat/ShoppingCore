using System;
using System.Collections.Generic;
using System.Text;

using ShoppingCore.Domain.Common;
using ShoppingCore.Domain.Products;
using ShoppingCore.Domain.Sellers;

namespace ShoppingCore.Domain.Interfaces
{
    public interface IProduct
    {
        int? ProductID { get; set; }

        string Name { get; set; }

        string ProductTitle { get; set; }

        string ProductDescription { get; set; }

        List<ProductCategory> ProductCategories { get; set; }

        List<ProductImage> ProductImages { get; set; }

        Units Unit { get; set; }

        string Currency { get; set; }

        float UnitPrice { get; set; }

        Seller Seller { get; set; }

        int SellerID { get; set; }
    }
}
