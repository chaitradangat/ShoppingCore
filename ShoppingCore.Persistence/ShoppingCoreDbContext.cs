using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;

using ShoppingCore.Domain.Common;
using ShoppingCore.Domain.Customers;
using ShoppingCore.Domain.Products;
using ShoppingCore.Domain.Sellers;
using ShoppingCore.Domain.Users;
using ShoppingCore.Persistence.Interfaces;


namespace ShoppingCore.Persistence
{
    public class ShoppingCoreDbContext : DbContext,IDataBaseService
    {
        public ShoppingCoreDbContext(DbContextOptions<ShoppingCoreDbContext> options) : base(options)
        {

        }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<Seller> Sellers { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShoppingCoreDbContext).Assembly);
        }

    }
}