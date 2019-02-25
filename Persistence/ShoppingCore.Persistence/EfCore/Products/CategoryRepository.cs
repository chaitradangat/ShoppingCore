using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.EntityFrameworkCore;

using ShoppingCore.Application.Interfaces;
using ShoppingCore.Domain.Common;
using ShoppingCore.Domain.Products;

using ShoppingCore.Persistence.EfCore.Interfaces;



namespace ShoppingCore.Persistence.EfCore.Products
{
    public class CategoryRepository : IRepository<Category>
    {
        IEfcoreDatabaseService _efcoreDatabase;

        public CategoryRepository(IEfcoreDatabaseService efcoreDatabase)
        {
            _efcoreDatabase = efcoreDatabase;
        }

        public void Add(Category category)
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

        public void Delete(Category category)
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

        public IEntity Find(int CategoryID)
        {
            return _efcoreDatabase.Categories
                    .Include(c => c.ProductCategories)
                    .Where(c => c.CategoryID == CategoryID)
                    .FirstOrDefault();
        }

        public IQueryable<Category> List()
        {
            return _efcoreDatabase.Categories
                    .Include(c => c.ProductCategories)
                     as IQueryable<Category>;
        }

        public void Update(Category category)
        {
            try
            {
                _efcoreDatabase.Categories.Attach(category).State = EntityState.Modified;
            }
            catch (Exception)
            {
                throw new Exception("Error updating " + nameof(Category) + " Entity.");
            }

            #region -old code-
            /*
            var _category = _efcoreDatabase.Categories.Find(category.CategoryID);

            if (_category != null)
            {
                _category.CategoryName = category.CategoryName;
                //_category.ProductCategories = category.ProductCategories;
                _category.SubCategory = category.SubCategory;
                _efcoreDatabase.Categories.Update(_category);
            }
            else
            {
                throw new Exception("Error updating " + nameof(Category)  +" Entity.");
            }
            */
            #endregion
        }
    }
}
