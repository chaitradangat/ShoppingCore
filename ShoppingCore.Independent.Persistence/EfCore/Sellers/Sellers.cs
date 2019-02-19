using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;

using ShoppingCore.Independent.Persistence.Interfaces;
using ShoppingCore.Independent.Persistence.EfCore.Interfaces;
using ShoppingCore.Domain.Sellers;
using ShoppingCore.Domain.Common;

namespace ShoppingCore.Independent.Persistence.EfCore.Sellers
{
    public class Sellers : IRepository<Seller>
    {
        protected readonly IEfcoreDatabaseService _efcoredatabase;

        public Sellers(IEfcoreDatabaseService efcoredatabase)
        {
            efcoredatabase = _efcoredatabase;
        }

        public IQueryable<Seller> List()
        {
            return _efcoredatabase.Sellers.AsQueryable();
        }

        public IEntity Find(int sellerID)
        {
            return _efcoredatabase.Sellers.Find(sellerID);

        }

        public void Add(Seller seller)
        {

        }

        public void Update(Seller seller)
        {

        }

        public void Delete(Seller seller)
        {

        }
    }
}
