using ShoppingCore.Application.Interfaces;
using System;
using System.Collections.Generic;
using ShoppingCore.Domain.Interfaces;

namespace ShoppingCore.Application.ApplicationModels
{
    public class ProductModel : IAppModel
    {
        public int ProductID { get; set; }

        public string Name { get; set; }

        public string ProductTitle { get; set; }

        public string ProductDescription { get; set; }

        public List<ProductCategoryModel> ProductCategories { get; set; }

        public List<ProductImageModel> ProductImages { get; set; }

        public Units Unit { get; set; }

        public string Currency { get; set; }

        public float UnitPrice { get; set; }

        public SellerModel Seller { get; set; }
    }
}
