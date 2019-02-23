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
    public class ProductImageRepository : IRepository<ProductImage>
    {
        private readonly IEfcoreDatabaseService _efcoreDatabase;

        public ProductImageRepository(IEfcoreDatabaseService efcoreDatabase)
        {
            _efcoreDatabase = efcoreDatabase;
        }

        void IRepository<ProductImage>.Add(ProductImage productImage)
        {
            try
            {
                _efcoreDatabase.ProductImages.Add(productImage);
            }
            catch (Exception)
            {
                throw;
            }
        }

        void IRepository<ProductImage>.Delete(ProductImage productImage)
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

        IEntity IRepository<ProductImage>.Find(int ProductImageID)
        {
            return _efcoreDatabase.ProductImages.Find(ProductImageID);
        }

        IQueryable<ProductImage> IRepository<ProductImage>.List()
        {
            return _efcoreDatabase.ProductImages as IQueryable<ProductImage>;
        }

        void IRepository<ProductImage>.Update(ProductImage productImage)
        {
            var _productImage = _efcoreDatabase.ProductImages.Find(productImage.ProductImageID);

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
            }
        }
    }
}
