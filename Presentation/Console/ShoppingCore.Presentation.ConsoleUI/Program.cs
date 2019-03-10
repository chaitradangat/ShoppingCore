using System;
using System.Linq;

using System.Collections.Generic;

//usings for dependency injection
using Microsoft.Extensions.DependencyInjection;
using ShoppingCore.DependencyInjection;

//usings for application commands
using ShoppingCore.Application.ApplicationModels;
using ShoppingCore.Application.Customers.Queries.GetCustomerDetail;
using ShoppingCore.Application.Users.Commands.CreateUser;

using ShoppingCore.Application.Customers.Queries.GetAllCustomers;

//testing namespaces
using Microsoft.EntityFrameworkCore;
using ShoppingCore.Domain.Common;
using ShoppingCore.Application.Interfaces;
using ShoppingCore.Provider.EfCore;
using ShoppingCore.Domain.Users;
using ShoppingCore.Domain.Customers;

namespace ShoppingCore.Presentation.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            DIContainer.InjectDependencies();


            #region customer-details-query
            //#testing customer details query
            //var query = DIContainer.Serviceprovider.GetService<IGetCustomerDetailQuery>();

            //var results = query.Execute().Where(cm => cm.UserID == -1);

            //var _results = results.ToList();
            #endregion


            #region customer-get-all
            //var query = DIContainer.Serviceprovider.GetService<IGetAllCustomers>();

            //var results = query.Execute().Where(c => c.LastName.Length > 0);

            //var _results = results.ToList();
            #endregion


            #region testing code after removing navigational properties
            //var persistence = DIContainer.Serviceprovider.GetService<IPersistence<IEntity>>();

            //var users = persistence.Users.List();

            //var _users = users.ToList();
            #endregion


            #region testing the dbcontext
            //using (var db = new ShoppingCoreDbContext())
            //{
            //    var users = db.Users;

            //    var _users = db.Users as IQueryable<User>;

            //    var result = _users.Where(u => u.UserID > 0).ToList();
            //}
            #endregion


            //testing cascade delete
            using (var db = new ShoppingCoreDbContext())
            {
                var customers = db.Customers.Include(c => c.User)
                    .Include(c => c.Addresses)
                    .ThenInclude(ca => ca.Address)
                    as IQueryable<Customer>;

                var customer = customers.Where(c => c.Addresses.Where(a => a.Address.City != "").Count() > 0).SingleOrDefault();

                db.Customers.Remove(customer);

                db.Save();
            }





            //#todo: use IQueryable in domain models instead of List for navigation properties

            Console.WriteLine("Hello World!");

            Console.ReadLine();
        }

        /* test code will be removed later..
        public static IAppModel MockAppModel(IDatabaseService database, IDomainFactory domainFactory)
        {
            //fetch sample data from database to mock
            var customer = database.Customers.LoadRelatedEntities().Where(c => c.FirstName.Contains("test") && c.Addresses.Count > 0).FirstOrDefault();
            //var customer = database.Customers.LoadRelatedEntities().Where(c => c.FirstName.Contains("test")).FirstOrDefault();

            //create appmodel
            var customerModel = new CustomerModel()
            {

                UserID = customer.User.UserID,

                UserName = customer.User.UserName,

                Password = customer.User.Password,

                IsAutheticated = customer.User.IsAutheticated,

                AutheticationType = customer.User.AutheticationType,

                UserRole = customer.User.UserRole,

                CustomerID = customer.CustomerID,

                FirstName = customer.FirstName,

                MiddleName = customer.MiddleName,

                LastName = customer.LastName,

                Gender = customer.Gender,

                DateOfBirth = customer.DateOfBirth
            };

            customer.Addresses.ForEach(a => customerModel.Addresses.Add(
               new AddressModel()
               {
                   AddressLine1 = a.AddressLine1,
                   AddressLine2 = a.AddressLine2,
                   AddressLine3 = a.AddressLine3,
                   AddressLine4 = a.AddressLine4,
                   AddressLine5 = a.AddressLine5,
                   AddressType = a.AddressType,
                   City = a.City,
                   Country = a.Country,
                   District = a.District,
                   LandMark = a.LandMark,
                   PinCode = a.PinCode,
                   AddressID = a.AddressID,
                   //CustomerID = a.Customer.CustomerID
               }));

            //add custom data to mock as if it was added by user
            customerModel.Addresses.Add(new AddressModel() { AddressLine1 = "addressline1 test", AddressLine2 = "addressline2 test", City = "city test" });

            //remove address to mock address has been deleted by user 
            customerModel.Addresses.RemoveAll(a => a.AddressID == 58);

            return customerModel;
        }
        */

        /* test code will be removed later
        public static IAppModel MockCustomerAppModel(IDatabaseService database, IDomainFactory domainFactory)
        {
            var customerAppModel = new CustomerModel();

            customerAppModel.Addresses.Add(new AddressModel() { AddressLine1 = "insert line1",AddressLine2 = "insert line2",Country = "India" });
            customerAppModel.Addresses.Add(new AddressModel() { AddressLine1 = "insert line1", AddressLine2 = "insert line2", Country = "USA" });
            customerAppModel.Addresses.Add(new AddressModel() { AddressLine1 = "insert line1", AddressLine2 = "insert line2", Country = "UK" });
            customerAppModel.Addresses.Add(new AddressModel() { AddressLine1 = "insert line1", AddressLine2 = "insert line2", Country = "Canada" });

            customerAppModel.AutheticationType = Domain.Common.AutheticationType.AppDatabase;
            customerAppModel.DateOfBirth = DateTime.Now;

            customerAppModel.Gender = "Female";
            customerAppModel.IsAutheticated = false;

            customerAppModel.FirstName = "insert first name";
            customerAppModel.MiddleName = "insert middle name";
            customerAppModel.Password = "pwrd";
            customerAppModel.UserName = "insert username";

            customerAppModel.UserRole = Domain.Common.UserRole.Customer;

            return customerAppModel;
        } */

    }
}