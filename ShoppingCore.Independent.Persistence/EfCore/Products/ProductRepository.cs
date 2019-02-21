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
    public class ProductRepository : IRepository<Product>
    {
        IEfcoreDatabaseService _efcoreDatabase;

        public ProductRepository(IEfcoreDatabaseService efcoreDatabase)
        {
            _efcoreDatabase = efcoreDatabase;
        }

        void IRepository<Product>.Add(Product product)
        {
            try
            {
                _efcoreDatabase.Products.Add(product);
            }
            catch (Exception)
            {
                throw;
            }
        }

        void IRepository<Product>.Delete(Product product)
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

        IEntity IRepository<Product>.Find(int ProductID)
        {
            return _efcoreDatabase.Products.Find(ProductID);
        }

        IQueryable<Product> IRepository<Product>.List()
        {
            return _efcoreDatabase.Products as IQueryable<Product>;
        }

        void IRepository<Product>.Update(Product product)
        {
            var _product = _efcoreDatabase.Products.Find(product.ProductID);

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
            }

        }
    }
}
