using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;

using ShoppingCore.Domain.Common;
using ShoppingCore.Domain.Customers;
using ShoppingCore.Domain.Products;
using ShoppingCore.Domain.Sellers;
using ShoppingCore.Domain.Users;
using ShoppingCore.Application.Interfaces;
using System.Configuration;
using System.IO;
using ShoppingCore.Domain.Interfaces;

namespace ShoppingCore.Persistence
{
    public class ShoppingCoreDbContext : DbContext,IDatabaseService
    {
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
            var persistenceConfigPath = Convert.ToString(Directory.GetCurrentDirectory());
            persistenceConfigPath = persistenceConfigPath.Remove(persistenceConfigPath.IndexOf("ShoppingCore"));
            persistenceConfigPath += @"ShoppingCore\ShoppingCore.Persistence\bin\Debug\netcoreapp2.1\ShoppingCore.Persistence.dll.config";
            return persistenceConfigPath;
        }
        #endregion

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

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
    }
}