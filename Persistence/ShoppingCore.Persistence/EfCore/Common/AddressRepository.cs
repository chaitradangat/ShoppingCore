using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;


using ShoppingCore.Domain.Interfaces;
using ShoppingCore.Domain.Customers;
using ShoppingCore.Domain.Products;
using ShoppingCore.Persistence.Interfaces;
using System.Linq;

using ShoppingCore.Application.Interfaces;
using ShoppingCore.Domain.Common;

namespace ShoppingCore.Persistence.EfCore.Common
{
    public class AddressRepository : IRepository<Address>
    {
        private readonly IEfcoreDatabaseService _efcoreDatabase;

        public AddressRepository(IEfcoreDatabaseService efcoreDatabase)
        {
            _efcoreDatabase = efcoreDatabase;
        }

        public IQueryable<Address> List()
        {
            return _efcoreDatabase.Addresses
                //.Include(a => a.Customer)
                //.Include(a => a.Product)
                //.Include(a => a.Customer.User)
                //.Include(a => a.Product.Seller)
                //.Include(a=>a.Product.Seller.User)
                as IQueryable<Address>;
        }

        public IEntity Find(int AddressID)
        {
            return _efcoreDatabase.Addresses
                //.Include(a => a.Customer)
                //.Include(a => a.Product)
                //.Include(a => a.Customer.User)
                //.Include(a => a.Product.Seller)
                //.Include(a => a.Product.Seller.User)
                .Where(a => a.AddressID == AddressID)
                .FirstOrDefault();
        }

        public IEntity Add(Address address)
        {
            try
            {
                _efcoreDatabase.Addresses.Add(address);
                return address;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEntity Update(Address address)
        {
            try
            {
                _efcoreDatabase.Addresses.Attach(address).State = EntityState.Modified;
                return address;
            }
            catch (Exception)
            {
                throw new Exception("Error updating " + nameof(Address) + " Entity");
            }
            #region -bad code-
            //var _address = _efcoreDatabase.Addresses.Find(address.AddressID);

            //if (_address != null)
            //{
            //    _address.AddressLine1 = address.AddressLine1;
            //    _address.AddressLine2 = address.AddressLine2;
            //    _address.AddressLine3 = address.AddressLine3;
            //    _address.AddressLine4 = address.AddressLine4;
            //    _address.AddressLine5 = address.AddressLine5;
            //    _address.AddressType = address.AddressType;
            //    _address.City = address.City;
            //    _address.Country = address.Country;
            //    //_address.Customer = address.Customer;
            //    _address.District = address.District;
            //    _address.LandMark = address.LandMark;
            //    _address.PinCode = address.PinCode;
            //    //_address.Product = address.Product;

            //    _efcoreDatabase.Addresses.Update(_address);
            //}
            //else
            //{
            //    throw new Exception("Error updating " + nameof(Address) + " Entity");
            //}
            #endregion
        }

        public void Delete(Address address)
        {
            try
            {
                _efcoreDatabase.Addresses.Remove(address);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
