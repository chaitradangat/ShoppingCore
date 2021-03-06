﻿using ShoppingCore.Application.Interfaces;
using ShoppingCore.Domain.Interfaces;

namespace ShoppingCore.Application.ApplicationModels
{
    public class ProductCategoryModel : IAppModel
    {
        public ProductModel ProductModel { get; set; }

        public CategoryModel CategoryModel { get; set; }
    }
}
