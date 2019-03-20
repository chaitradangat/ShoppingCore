using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;

using ShoppingCore.Domain.Interfaces;
using ShoppingCore.Domain.Customers;
using ShoppingCore.Domain.Products;
using ShoppingCore.Domain.Sellers;
using ShoppingCore.Domain.Users;
using ShoppingCore.Application.Interfaces;
using System.Configuration;
using System.IO;
using System.Linq.Expressions;
using System.Linq;
using ShoppingCore.Persistence.Interfaces;
using ShoppingCore.Domain.Common;

namespace ShoppingCore.Provider.EfCore
{
    public class ShoppingCoreDbContext : DbContext,IEfcoreDatabaseService
    {
        public ShoppingCoreDbContext()
        {
            //this ctor requires no arguments..can be used for testing the DbContext directly.
        }

        public ShoppingCoreDbContext(DbContextOptions<ShoppingCoreDbContext> options) : base(options)
        {
            
        }

        #region -Code for constring and provider setting-
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config =
            ConfigurationManager.OpenMappedExeConfiguration(
                new ExeConfigurationFileMap { ExeConfigFilename = GetPersistenceConfigPath() },
                ConfigurationUserLevel.None);

            var connectionString = config.ConnectionStrings.ConnectionStrings["ShoppingCoreConstr"].ConnectionString;

            optionsBuilder
                .UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }

        private string GetPersistenceConfigPath()
        {
            return Directory.GetCurrentDirectory() + "\\ShoppingCore.Provider.EfCore.dll.config";
        }
        #endregion

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<CustomerAddress> CustomerAddresses { get; set; }


        public DbSet<Product> Products { get; set; }

        public DbSet<ProductAddress> ProductAddresses { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }


        public DbSet<Seller> Sellers { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }

        public void Save()
        {
            this.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShoppingCoreDbContext).Assembly);

            modelBuilder.SeedAllData();
        }

        //public IQueryable<T> Include<T>(string [] Properties)
        //{
        //    if (typeof(T) == typeof(Customer))
        //    {
        //        IQueryable<Customer> result = null;

        //        foreach (var property in Properties)
        //        {
        //            if (result == null)
        //            {
        //                result = Customers.Include(property);
        //            }
        //            else
        //            {
        //                result = result.Include(property);
        //            }
        //        }

        //        return (IQueryable<T>)result;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
    }
}