using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCore.Application.Interfaces;
using ShoppingCore.Application.Users.Commands.CreateUser;
using ShoppingCore.Application.Users.Commands.CreateUser.Factory;
using ShoppingCore.Persistence;
using ShoppingCore.Application.Customers.Commands.CreateCustomer;
using ShoppingCore.Domain.Interfaces;
using ShoppingCore.Domain.XDomainFactory;
using ShoppingCore.Domain.Common;
using ShoppingCore.Domain.Products;
using ShoppingCore.Domain.Users;
using ShoppingCore.Domain.Customers;
using ShoppingCore.Domain.Sellers;

namespace ShoppingCore.DependencyInjection
{
    public class DIContainer
    {
        public static ServiceProvider Serviceprovider { get; private set; }

        public static void InjectDependencies()
        {
            Serviceprovider = new ServiceCollection()
            .AddTransient<IAddress,Address>()
            .AddTransient<ICategory,Category>()
            .AddTransient<IProductCategory,ProductCategory>()
            .AddTransient<IProduct,Product>()
            .AddTransient<IUser,User>()
            .AddTransient<ICustomer,Customer>()
            .AddTransient<ISeller,Seller>()
            .AddTransient<IProductImage,ProductImage>()


            .AddDbContext<ShoppingCoreDbContext>()
            .AddSingleton<IDomainFactory,DomainFactory>()
            .AddSingleton<IDatabaseService, ShoppingCoreDbContext>()
            .AddSingleton<IUserFactory, UserFactory>()
            .AddSingleton<ICreateUserCommand, CreateUserCommand>()
            .AddSingleton<ICreateCustomerCommand, CreateCustomerCommand>()
            .BuildServiceProvider();
        }
    }
}