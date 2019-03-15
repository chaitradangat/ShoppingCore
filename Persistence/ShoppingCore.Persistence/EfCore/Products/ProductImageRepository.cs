using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

using ShoppingCore.Application.Interfaces;
using ShoppingCore.Domain.Interfaces;
using ShoppingCore.Domain.Products;
using ShoppingCore.Persistence.Interfaces;



namespace ShoppingCore.Persistence.EfCore.Products
{
    public class ProductImageRepository : IRepository<ProductImage>
    {
        private readonly IEfcoreDatabaseService _efcoreDatabase;

        public ProductImageRepository(IEfcoreDatabaseService efcoreDatabase)
        {
            _efcoreDatabase = efcoreDatabase;
        }

        public IEntity Add(ProductImage productImage)
        {
            try
            {
                _efcoreDatabase.ProductImages.Add(productImage);
                return productImage;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(ProductImage productImage)
        {
            try
            {
                _efcoreDatabase.ProductImages.Remove(productImage);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEntity Find(int ProductImageID)
        {
            return
            _efcoreDatabase.ProductImages
                .Include(pi => pi.Product)
                .Where(pi => pi.ProductImageID == ProductImageID)
                .FirstOrDefault();
        }

        public IQueryable<ProductImage> List()
        {
            return
            _efcoreDatabase.ProductImages
                .Include(pi => pi.Product)
                as IQueryable<ProductImage>;
        }

        public IEntity Update(ProductImage productImage)
        {
            try
            {
                _efcoreDatabase.ProductImages.Attach(productImage).State = EntityState.Modified;
                return productImage;
            }
            catch (Exception)
            {
                throw new Exception("Error Updating " + nameof(ProductImage) + " Entity.");
            }

            #region -bad code-
            /*var _productImage = _efcoreDatabase.ProductImages.Find(productImage.ProductImageID);

            if (_productImage != null)
            {
                _productImage.ImageUrl = productImage.ImageUrl;
                _productImage.Product = productImage.Product;
                _productImage.ProductID = productImage.ProductID;
                _efcoreDatabase.ProductImages.Update(_productImage);
            }
            else
            {
                throw new Exception("Error Updating " + nameof(ProductImage) + " Entity.");
            }*/
            #endregion
        }
    }
}
