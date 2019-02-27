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
    public class ProductRepository : IRepository<Product>
    {
        IEfcoreDatabaseService _efcoreDatabase;

        public ProductRepository(IEfcoreDatabaseService efcoreDatabase)
        {
            _efcoreDatabase = efcoreDatabase;
        }

        public IEntity Add(Product product)
        {
            try
            {
                _efcoreDatabase.Products.Add(product);
                return product;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(Product product)
        {
            try
            {
                _efcoreDatabase.Products.Remove(product);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEntity Find(int ProductID)
        {
            return
            _efcoreDatabase.Products.Include(p => p.Address)
                .Include(p => p.ProductCategories)
                .Include(p => p.ProductImages)
                .Include(p => p.Seller)
                .Include(p => p.Seller.User)
                .Where(p => p.ProductID == ProductID)
                .SingleOrDefault();
        }

        public IQueryable<Product> List()
        {
            return
               _efcoreDatabase.Products.Include(p => p.Address)
                .Include(p => p.ProductCategories)
                .Include(p => p.ProductImages)
                .Include(p => p.Seller)
                .Include(p => p.Seller.User)
                as IQueryable<Product>;
        }

        public IEntity Update(Product product)
        {
            try
            {
                _efcoreDatabase.Products.Attach(product).State = EntityState.Modified;
                return product;
            }
            catch (Exception)
            {
                throw new Exception("Error Updating " + nameof(Product) + " entity.");
            }

            #region -bad code-
            /*var _product = _efcoreDatabase.Products.Find(product.ProductID);

           if (_product != null)
           {
               _product.Currency = product.Currency;
               _product.Name = product.Name;
               _product.ProductCategories = product.ProductCategories;
               _product.ProductDescription = product.ProductDescription;
               _product.ProductImages = product.ProductImages;
               _product.ProductTitle = product.ProductTitle;
               _product.Seller = product.Seller;
               _product.SellerID = product.SellerID;
               _product.Unit = product.Unit;
               _product.UnitPrice = product.UnitPrice;
               _efcoreDatabase.Products.Update(_product);
           }
           else
           {
               throw new Exception("Error Updating " + nameof(Product) + " entity.");
           }*/
            #endregion
        }
    }
}
