using System;
using System.Collections.Generic;
using System.Text;

using ShoppingCore.Independent.Persistence.EfCore.Interfaces;
using ShoppingCore.Independent.Persistence.Interfaces;
using ShoppingCore.Domain.Customers;
using ShoppingCore.Domain.Common;
using System.Linq;

namespace ShoppingCore.Independent.Persistence.EfCore.Customers
{
    public class Customers : IRepository<Customer>
    {
        IEfcoreDatabaseService _efcoreDatabase;

        public Customers(IEfcoreDatabaseService efcoreDatabase)
        {
            _efcoreDatabase = efcoreDatabase;
        }


        public void Add(Customer customer)
        {
            try
            {
                _efcoreDatabase.Customers.Add(customer);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(Customer customer)
        {
            try
            {
                _efcoreDatabase.Customers.Remove(customer);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEntity Find(int CustomerID)
        {
            return _efcoreDatabase.Customers.Find(CustomerID);
        }

        public IQueryable<Customer> List()
        {
            return _efcoreDatabase.Customers as IQueryable<Customer>;
        }

        public void Update(Customer customer)
        {
            var _customer = _efcoreDatabase.Customers.Find(customer.CustomerID);

            if (_customer != null)
            {
                _customer.Addresses = customer.Addresses;
                _customer.DateOfBirth = customer.DateOfBirth;
                _customer.FirstName = customer.FirstName;
                _customer.Gender = customer.Gender;
                _customer.LastName = customer.LastName;
                _customer.MiddleName = customer.MiddleName;
                _customer.User = customer.User;

                _efcoreDatabase.Customers.Update(_customer);
            }
            else
            {
                throw new Exception("Error Updating " + nameof(Customer) + " Entity");
            }
        }
    }
}
