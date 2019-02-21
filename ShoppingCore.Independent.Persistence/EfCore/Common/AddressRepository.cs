using System;
using System.Collections.Generic;
using System.Text;



using ShoppingCore.Domain.Common;
using ShoppingCore.Domain.Customers;
using ShoppingCore.Domain.Products;
using ShoppingCore.Persistence.EfCore.Interfaces;
using System.Linq;
using ShoppingCore.Domain.Interfaces;

using ShoppingCore.Application.Interfaces;

namespace ShoppingCore.Persistence.EfCore.Common
{
    public class AddressRepository : IRepository<Address>
    {
        private readonly IEfcoreDatabaseService _efcoreDatabase;

        public AddressRepository(IEfcoreDatabaseService efcoreDatabase)
        {
            _efcoreDatabase = efcoreDatabase;
        }

        IQueryable<Address> IRepository<Address>.List()
        {
            return _efcoreDatabase.Addresses as IQueryable<Address>;
        }

        IEntity IRepository<Address>.Find(int AddressID)
        {
            var address = _efcoreDatabase.Addresses.Find(AddressID);
            return address;
        }

        void IRepository<Address>.Add(Address address)
        {
            try
            {
                _efcoreDatabase.Addresses.Add(address);
            }
            catch (Exception)
            {
                throw;
            }
        }

        void IRepository<Address>.Update(Address address)
        {
            var _address = _efcoreDatabase.Addresses.Find(address.AddressID);

            if (_address != null)
            {
                _address.AddressLine1 = address.AddressLine1;
                _address.AddressLine2 = address.AddressLine2;
                _address.AddressLine3 = address.AddressLine3;
                _address.AddressLine4 = address.AddressLine4;
                _address.AddressLine5 = address.AddressLine5;
                _address.AddressType = address.AddressType;
                _address.City = address.City;
                _address.Country = address.Country;
                //_address.Customer = address.Customer;
                _address.District = address.District;
                _address.LandMark = address.LandMark;
                _address.PinCode = address.PinCode;
                //_address.Product = address.Product;

                _efcoreDatabase.Addresses.Update(_address);
            }
            else
            {
                throw new Exception("Error updating " + nameof(Address) + " Entity");
            }
        }

        void IRepository<Address>.Delete(Address address)
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
