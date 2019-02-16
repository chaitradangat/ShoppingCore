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
using Microsoft.EntityFrameworkCore.Design;

//using Microsoft.EntityFrameworkCore;

using ShoppingCore.Application.Customers.Commands.CreateCustomer;
using ShoppingCore.Application.ApplicationModels;
using ShoppingCore.Domain.Interfaces;

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

            var customersWithoutInclude = database.Customers.Where(c => c.FirstName.Contains("test")).ToList();

            
            //var customers = database.Customers.Include(c => c.User)
            //                .Where(c => c.FirstName.Contains("test"))
            //                .ToList();
            #endregion

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}