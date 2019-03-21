using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;

using System.Linq;
using ShoppingCore.Persistence.Interfaces;

using ShoppingCore.Domain.Sellers;
using ShoppingCore.Domain.Interfaces;
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
            return
                _efcoredatabase.Sellers
                  .Include(s => s.User)
                  as IQueryable<Seller>;
        }

        public IEntity Find(int sellerID)
        {
            return
                _efcoredatabase.Sellers
                .Include(s => s.User)
                .Where(s => s.SellerID == sellerID).FirstOrDefault();
        }

        public IEntity Add(Seller seller)
        {
            try
            {
                _efcoredatabase.Sellers.Add(seller);
                return seller;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEntity Update(Seller seller)
        {
            try
            {
                _efcoredatabase.Sellers.Attach(seller).State = EntityState.Modified;
                return seller;
            }
            catch (Exception)
            {
                throw new Exception("Error updating " + nameof(Seller) + " entity");
            }
            #region -bad code-
            /*var _seller = _efcoredatabase.Sellers.Find(seller.SellerID);

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
            }*/
            #endregion
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
