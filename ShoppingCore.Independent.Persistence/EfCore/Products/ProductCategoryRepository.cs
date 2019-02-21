using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShoppingCore.Application.Interfaces;
using ShoppingCore.Domain.Common;
using ShoppingCore.Domain.Products;
using ShoppingCore.Persistence.EfCore.Interfaces;


namespace ShoppingCore.Persistence.EfCore.Products
{
    public class ProductCategoryRepository : IRepository<ProductCategory>
    {
        private readonly IEfcoreDatabaseService _efcoreDatabase;

        public ProductCategoryRepository(IEfcoreDatabaseService efcoreDatabase)
        {
            _efcoreDatabase = efcoreDatabase;
        }

        void IRepository<ProductCategory>.Add(ProductCategory productCategory)
        {
            try
            {
                _efcoreDatabase.ProductCategories.Add(productCategory);
            }
            catch (Exception)
            {
                throw;
            }
        }

        void IRepository<ProductCategory>.Delete(ProductCategory productCategory)
        {
            try
            {
                // this method is going to give error
                _efcoreDatabase.ProductCategories.Remove(productCategory);
            }
            catch (Exception)
            {
                throw;
            }
        }

        IEntity IRepository<ProductCategory>.Find(int ProductCategoryID)
        {
            return _efcoreDatabase.ProductCategories.Find(ProductCategoryID);
        }

        IQueryable<ProductCategory> IRepository<ProductCategory>.List()
        {
            return _efcoreDatabase.ProductCategories as IQueryable<ProductCategory>;
        }

        void IRepository<ProductCategory>.Update(ProductCategory productCategory)
        {
            var _productCategory = _efcoreDatabase.ProductCategories.Find(productCategory);

            if (_productCategory != null)
            {
                _productCategory.Category = productCategory.Category;
                _productCategory.CategoryID = productCategory.CategoryID;
                _productCategory.Product = productCategory.Product;
                _productCategory.ProductID = productCategory.ProductID;
                _efcoreDatabase.ProductCategories.Update(_productCategory);
            }
            else
            {
                throw new Exception("Error Updating " + nameof(ProductCategory) + " Entity.");
            }
        }
    }
}
