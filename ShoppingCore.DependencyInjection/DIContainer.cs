using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCore.Application.Interfaces;
using ShoppingCore.Application.Users.Commands.CreateUser;
using ShoppingCore.Application.Users.Commands.CreateUser.Factory;
using ShoppingCore.Persistence;

namespace ShoppingCore.DependencyInjection
{
    public class DIContainer
    {
        public static ServiceProvider Serviceprovider { get; private set; }

        public static void InjectDependencies()
        {
            Serviceprovider = new ServiceCollection()
            .AddDbContext<ShoppingCoreDbContext>()
            .AddSingleton<IDatabaseService, ShoppingCoreDbContext>()
            .AddSingleton<IUserFactory, UserFactory>()
            .AddSingleton<ICreateUserCommand, CreateUserCommand>()
            .BuildServiceProvider();
        }
    }
}