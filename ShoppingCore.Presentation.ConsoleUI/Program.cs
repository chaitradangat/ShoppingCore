using System;

using Microsoft.Extensions.DependencyInjection;

using ShoppingCore.Application.Users.Commands.CreateUser;
using ShoppingCore.Application.Users.Commands.CreateUser.Factory;
using ShoppingCore.Application.Interfaces;
using ShoppingCore.Persistence;
using Microsoft.EntityFrameworkCore.Design;

namespace ShoppingCore.Presentation.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceprovider = new ServiceCollection()
            .AddDbContext<ShoppingCoreDbContext>()
            .AddSingleton<IDatabaseService, ShoppingCoreDbContext>()
            .AddSingleton<IUserFactory, UserFactory>()
            .AddSingleton<ICreateUserCommand, CreateUserCommand>()
            .BuildServiceProvider();

            var c = serviceprovider.GetService<ICreateUserCommand>();

            c.Execute(new CreateUserModel() { UserName = "abc", Password = "def" });



            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }

}
