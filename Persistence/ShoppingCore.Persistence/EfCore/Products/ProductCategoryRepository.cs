using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.EntityFrameworkCore;

using ShoppingCore.Application.Interfaces;
using ShoppingCore.Domain.Common;
using ShoppingCore.Domain.Products;
using ShoppingCore.Persistence.Interfaces;


namespace ShoppingCore.Persistence.EfCore.Products
{
    public class ProductCategoryRepository : IRepository<ProductCategory>
    {
        private readonly IEfcoreDatabaseService _efcoreDatabase;

        public ProductCategoryRepository(IEfcoreDatabaseService efcoreDatabase)
        {
            _efcoreDatabase = efcoreDatabase;
        }

        public IEntity Add(ProductCategory productCategory)
        {
            try
            {
                _efcoreDatabase.ProductCategories.Add(productCategory);
                return productCategory;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(ProductCategory productCategory)
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

        public IEntity Find(int ProductCategoryID)
        {
            return
            _efcoreDatabase.ProductCategories
                .Include(pc => pc.Product)
                .Include(pc => pc.Category)
                .Where(pc => pc.ProductCategoryID == ProductCategoryID)
                .FirstOrDefault();
        }

        public IQueryable<ProductCategory> List()
        {
            return
            _efcoreDatabase.ProductCategories
                .Include(pc => pc.Product)
                .Include(pc => pc.Category)
                as IQueryable<ProductCategory>;
        }

        public IEntity Update(ProductCategory productCategory)
        {
            try
            {
                _efcoreDatabase.ProductCategories.Attach(productCategory).State = EntityState.Modified;
                return productCategory;
            }
            catch (Exception)
            {
                throw new Exception("Error Updating " + nameof(ProductCategory) + " Entity.");
            }
            #region -bad code-
            /*
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
           } */
            #endregion
        }
    }
}
