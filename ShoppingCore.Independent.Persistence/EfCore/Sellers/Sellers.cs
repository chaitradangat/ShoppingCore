using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using ShoppingCore.Persistence.EfCore.Interfaces;

using ShoppingCore.Domain.Sellers;
using ShoppingCore.Domain.Common;
using ShoppingCore.Application.Interfaces;

namespace ShoppingCore.Persistence.EfCore.Sellers
{
    public class SellerRepository : IRepository<Seller>
    {
        protected readonly IEfcoreDatabaseService _efcoredatabase;

        public SellerRepository(IEfcoreDatabaseService efcoredatabase)
        {
            efcoredatabase = _efcoredatabase;
        }

        public IQueryable<Seller> List()
        {
            return _efcoredatabase.Sellers as IQueryable<Seller>;
        }

        public IEntity Find(int sellerID)
        {
            return _efcoredatabase.Sellers.Find(sellerID);

        }

        public void Add(Seller seller)
        {
            try
            {
                _efcoredatabase.Sellers.Add(seller);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Seller seller)
        {
            var _seller = _efcoredatabase.Sellers.Find(seller.SellerID);

            if (_seller != null)
            {
                _seller.BusinessName = seller.BusinessName;
                _seller.DateOfBirth = seller.DateOfBirth;
                _seller.FirstName = seller.FirstName;
                _seller.Gender = seller.Gender;
                _seller.LastName = seller.LastName;
                _seller.MiddleName = seller.MiddleName;
                _seller.Products = seller.Products;
                _seller.User = seller.User;
                _efcoredatabase.Sellers.Update(_seller);
            }
            else
            {
                throw new Exception("Error updating " + nameof(Seller) + " entity");
            }
        }

        public void Delete(Seller seller)
        {
            try
            {
                _efcoredatabase.Sellers.Remove(seller);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
