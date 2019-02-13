using System;

using Microsoft.Extensions.DependencyInjection;

using ShoppingCore.DependencyInjection;

using ShoppingCore.Application.Users.Commands.CreateUser;
using ShoppingCore.Application.Users.Commands.CreateUser.Factory;
using ShoppingCore.Application.Interfaces;
using ShoppingCore.Persistence;
using Microsoft.EntityFrameworkCore.Design;
using ShoppingCore.Application.Customers.Commands.CreateCustomer;

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
            command.Execute(null);



            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}