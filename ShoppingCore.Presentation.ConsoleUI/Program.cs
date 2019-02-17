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

namespace ShoppingCore.Presentation.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            DIContainer.InjectDependencies();

            #region -Create User Command Test-
            //ICreateUserCommand command = DIContainer.Serviceprovider.GetService<ICreateUserCommand>();
            //command.Execute(new CreateUserModel() { UserName="xxx", Password = "zzz" });
            #endregion

            #region -Create Customer Command Test-
            //ICreateCustomerCommand command = DIContainer.Serviceprovider.GetService<ICreateCustomerCommand>();
            //CustomerModel customerModel = new CustomerModel(DIContainer.Serviceprovider.GetService<IDomainFactory>())
            //{
            //    Addresses = new System.Collections.Generic.List<AddressModel>(),
            //    AutheticationType = Domain.Common.AutheticationType.AppDatabase,
            //    DateOfBirth = DateTime.Now,
            //    FirstName = "FirstName test",
            //    Gender = "Male",
            //    LastName = "LastName test",
            //    MiddleName = "MiddleName test",
            //    Password = "psswrd",
            //    UserName = "UserName test",
            //    UserRole = Domain.Common.UserRole.Customer
            //};
            //command.Execute(customerModel);
            #endregion

            #region -Loading related Entities-
            //loading related entities
            var database = DIContainer.Serviceprovider.GetService<IDatabaseService>();
            var domainfactory = DIContainer.Serviceprovider.GetService<IDomainFactory>();

            #endregion

            #region -Updating Entities-

            IUpdateCustomerCommand cmd = DIContainer.Serviceprovider.GetService<IUpdateCustomerCommand>();

            var customerModel = MockAppModel(database, domainfactory) as CustomerModel;

            customerModel = cmd.Execute(customerModel) as CustomerModel;

            #endregion

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }


        public static IAppModel MockAppModel(IDatabaseService database,IDomainFactory domainFactory)
        {
            //fetch sample data from database to mock
            var customer = database.Customers.LoadRelatedEntities().Where(c => c.FirstName.Contains("test") && c.Addresses.Count > 1).FirstOrDefault();

            //declare appmodel
            var customerModel = new CustomerModel(domainFactory) { _entity = customer };

            //convert domain to appmodel for mocking
            customerModel =  customerModel.ConvertToAppModel() as CustomerModel;

            //set the domain entity to null for mock data as if it was passed by the view/another dto
            customerModel._entity = null;

            //add custom data to mock as if it was added by user
            customerModel.Addresses.Add(new AddressModel() { AddressLine1 = "addressline1 test", AddressLine2 = "addressline2 test", City = "city test" });

            return customerModel;
        }




    }
}