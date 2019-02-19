using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using Microsoft.Extensions.DependencyInjection;

using ShoppingCore.DependencyInjection;

using ShoppingCore.Application.Users.Commands.CreateUser;
using ShoppingCore.Application.Users.Commands.CreateUser.Factory;
using ShoppingCore.Application.Interfaces;
using ShoppingCore.Persistence;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;



using ShoppingCore.Application.Customers.Commands.CreateCustomer;
using ShoppingCore.Application.ApplicationModels;
using ShoppingCore.Domain.Interfaces;


using ShoppingCore.Persistence.Configurations;
using ShoppingCore.Application.Customers.Commands.UpdateCustomer;
using ShoppingCore.Domain.Customers;
using ShoppingCore.Application.Customers.Queries.GetCustomerDetail;
using ShoppingCore.Independent.Persistence.Interfaces;
using ShoppingCore.Independent.Persistence.EfCore.Interfaces;

using ShoppingCore.Independent.Persistence;
using ShoppingCore.Domain.Users;


namespace ShoppingCore.Presentation.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            DIContainer.InjectDependencies();

            //var database = DIContainer.Serviceprovider.GetService<IDatabaseService>();
            var domainfactory = DIContainer.Serviceprovider.GetService<IDomainFactory>();

            var database_independent = DIContainer.Serviceprovider.GetService<IEfcoreDatabaseService>();

            #region -Create User Command Test-
            //ICreateUserCommand command = DIContainer.Serviceprovider.GetService<ICreateUserCommand>();
            //command.Execute(new CreateUserModel() { UserName="xxx", Password = "zzz" });
            #endregion

            #region -Create Customer Command Test-
            //ICreateCustomerCommand command = DIContainer.Serviceprovider.GetService<ICreateCustomerCommand>();

            //var customerModel = command.Execute(MockCustomerAppModel(database, domainfactory) as CustomerModel) as CustomerModel;

            #endregion

            #region -Loading related Entities-
            //loading related entities

            #endregion

            #region -Updating Entities-

            //IUpdateCustomerCommand cmd = DIContainer.Serviceprovider.GetService<IUpdateCustomerCommand>();

            //var customerModel = MockAppModel(database, domainfactory) as CustomerModel;

            //customerModel = cmd.Execute(customerModel) as CustomerModel;

            #endregion

            #region -Get Customer Details-

            //var cmd = DIContainer.Serviceprovider.GetService<IGetCustomerDetailQuery>();
            //var customerModel = cmd.Execute(2) as CustomerModel;

            #endregion


            var users = DIContainer.Serviceprovider.GetService<IRepository<User>>();



            var ulist = users.List().ToList();




            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }

        public static IAppModel MockAppModel(IDatabaseService database, IDomainFactory domainFactory)
        {
            //fetch sample data from database to mock
            var customer = database.Customers.LoadRelatedEntities().Where(c => c.FirstName.Contains("test") && c.Addresses.Count > 0).FirstOrDefault();
            //var customer = database.Customers.LoadRelatedEntities().Where(c => c.FirstName.Contains("test")).FirstOrDefault();

            //create appmodel
            var customerModel = new CustomerModel(domainFactory)
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
                   CustomerID = a.Customer.CustomerID
               }));

            //add custom data to mock as if it was added by user
            customerModel.Addresses.Add(new AddressModel() { AddressLine1 = "addressline1 test", AddressLine2 = "addressline2 test", City = "city test" });

            //remove address to mock address has been deleted by user 
            customerModel.Addresses.RemoveAll(a => a.AddressID == 58);

            return customerModel;
        }

        public static IAppModel MockCustomerAppModel(IDatabaseService database, IDomainFactory domainFactory)
        {
            var customerAppModel = new CustomerModel(domainFactory);

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
        }



    }
}