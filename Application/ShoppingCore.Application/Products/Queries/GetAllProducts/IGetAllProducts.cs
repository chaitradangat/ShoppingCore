using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ShoppingCore.Application.ApplicationModels;

namespace ShoppingCore.Application.Products.Queries.GetAllProducts
{
    public interface IGetAllProducts
    {
        IQueryable<ProductModel> Execute();
    }
}
