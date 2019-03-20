using ShoppingCore.Application.Interfaces;
using ShoppingCore.Domain.Interfaces;
using ShoppingCore.Domain.Sellers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCore.Persistence.EfCore.Sellers
{
    public class SellerBusinessRepository : IRepository<SellerBusiness>
    {
        public IEntity Add(SellerBusiness entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(SellerBusiness entity)
        {
            throw new NotImplementedException();
        }

        public IEntity Find(int ID)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SellerBusiness> List()
        {
            throw new NotImplementedException();
        }

        public IEntity Update(SellerBusiness entity)
        {
            throw new NotImplementedException();
        }
    }
}
