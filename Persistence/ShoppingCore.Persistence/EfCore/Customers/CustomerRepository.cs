using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;

using ShoppingCore.Domain.Customers;
using ShoppingCore.Domain.Common;
using System.Linq;
using ShoppingCore.Application.Interfaces;
using ShoppingCore.Persistence.Interfaces;

namespace ShoppingCore.Persistence.EfCore.Customers
{
    public class CustomerRepository : IRepository<Customer>
    {
        IEfcoreDatabaseService _efcoreDatabase;

        public CustomerRepository(IEfcoreDatabaseService efcoreDatabase)
        {
            _efcoreDatabase = efcoreDatabase;
        }

        public IEntity Add(Customer customer)
        {
            try
            {
                _efcoreDatabase.Customers.Add(customer);
                return customer;
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
            return _efcoreDatabase.Customers.Include(c => c.Addresses)
                    .Include(c => c.User)
                    .Where(c => c.CustomerID == CustomerID)
                    .FirstOrDefault();
        }

        public IQueryable<Customer> List()
        {
            return _efcoreDatabase.Customers.Include(c => c.Addresses)
                                            .Include(c => c.User)
                                            as IQueryable<Customer>;
        }

        public IEntity Update(Customer customer)
        {
            try
            {
                _efcoreDatabase.Customers.Attach(customer).State = EntityState.Modified;
                return customer;
            }
            catch (Exception)
            {
                throw new Exception("Error Updating " + nameof(Customer) + " Entity");
            }

            #region -bad code-
            //var _customer = _efcoreDatabase.Customers.Find(customer.CustomerID);

            //if (_customer != null)
            //{
            //    _customer.Addresses = customer.Addresses;
            //    _customer.DateOfBirth = customer.DateOfBirth;
            //    _customer.FirstName = customer.FirstName;
            //    _customer.Gender = customer.Gender;
            //    _customer.LastName = customer.LastName;
            //    _customer.MiddleName = customer.MiddleName;
            //    _customer.User = customer.User;

            //    _efcoreDatabase.Customers.Update(_customer);
            //}
            //else
            //{
            //    throw new Exception("Error Updating " + nameof(Customer) + " Entity");
            //}
            #endregion
        }
    }
}
