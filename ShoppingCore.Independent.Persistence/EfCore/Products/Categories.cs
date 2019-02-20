using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShoppingCore.Domain.Common;
using ShoppingCore.Domain.Products;

using ShoppingCore.Independent.Persistence.EfCore.Interfaces;
using ShoppingCore.Independent.Persistence.Interfaces;


namespace ShoppingCore.Independent.Persistence.EfCore.Products
{
    public class Categories : IRepository<Category>
    {
        IEfcoreDatabaseService _efcoreDatabase;

        public Categories(IEfcoreDatabaseService efcoreDatabase)
        {
            _efcoreDatabase = efcoreDatabase;
        }

        void IRepository<Category>.Add(Category category)
        {
            try
            {
                _efcoreDatabase.Categories.Add(category);
            }
            catch (Exception)
            {
                throw;
            }
        }

        void IRepository<Category>.Delete(Category category)
        {
            try
            {
                _efcoreDatabase.Categories.Remove(category);
            }
            catch (Exception)
            {
                throw;
            }
        }

        IEntity IRepository<Category>.Find(int CategoryID)
        {
            return _efcoreDatabase.Categories.Find(CategoryID);
        }

        IQueryable<Category> IRepository<Category>.List()
        {
            return _efcoreDatabase.Categories as IQueryable<Category>;
        }

        void IRepository<Category>.Update(Category category)
        {
            var _category = _efcoreDatabase.Categories.Find(category.CategoryID);

            if (_category != null)
            {
                _category.CategoryName = category.CategoryName;
                _category.ProductCategories = category.ProductCategories;
                _category.SubCategory = category.SubCategory;
                _efcoreDatabase.Categories.Update(_category);
            }
            else
            {
                throw new Exception("Error updating " + nameof(Category)  +" Entity.");
            }

        }
    }
}
