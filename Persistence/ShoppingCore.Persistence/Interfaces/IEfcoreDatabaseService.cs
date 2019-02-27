using Microsoft.EntityFrameworkCore;
using ShoppingCore.Domain.Common;
using ShoppingCore.Domain.Customers;
using ShoppingCore.Domain.Products;
using ShoppingCore.Domain.Sellers;
using ShoppingCore.Domain.Users;

using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCore.Persistence.Interfaces
{
    public interface IEfcoreDatabaseService
    {
        DbSet<Address> Addresses { get; set; }

        DbSet<Customer> Customers { get; set; }

        DbSet<Product> Products { get; set; }

        DbSet<Category> Categories { get; set; }

        DbSet<ProductCategory> ProductCategories { get; set; }

        DbSet<ProductImage> ProductImages { get; set; }

        DbSet<Seller> Sellers { get; set; }

        DbSet<User> Users { get; set; }

        void Save();
    }
}