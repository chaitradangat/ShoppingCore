using System;

using Microsoft.Extensions.DependencyInjection;

using ShoppingCore.DependencyInjection;

using ShoppingCore.Application.Users.Commands.CreateUser;
using ShoppingCore.Application.Users.Commands.CreateUser.Factory;
using ShoppingCore.Application.Interfaces;
using ShoppingCore.Persistence;
using Microsoft.EntityFrameworkCore.Design;
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

            //ICreateUserCommand command = DIContainer.Serviceprovider.GetService<ICreateUserCommand>();
            //command.Execute(new CreateUserModel() { UserName="xxx", Password = "zzz" });


            ICreateCustomerCommand command = DIContainer.Serviceprovider.GetService<ICreateCustomerCommand>();

            CustomerModel customerModel = new CustomerModel(DIContainer.Serviceprovider.GetService<IDomainFactory>())
            {
                Addresses = new System.Collections.Generic.List<AddressModel>(),
                AutheticationType = Domain.Common.AutheticationType.AppDatabase,
                DateOfBirth = DateTime.Now,
                FirstName = "FirstName test",
                Gender = "Male",
                LastName = "LastName test",
                MiddleName = "MiddleName test",
                Password = "psswrd",
                UserName = "UserName test",
                UserRole = Domain.Common.UserRole.Customer
            };

            command.Execute(customerModel);



            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}