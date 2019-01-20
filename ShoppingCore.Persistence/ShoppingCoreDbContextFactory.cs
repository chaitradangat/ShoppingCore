using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;



using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.IO;

namespace ShoppingCore.Persistence
{
   public class ShoppingCoreDbContextFactory : IDesignTimeDbContextFactory<ShoppingCoreDbContext>
    {
        public ShoppingCoreDbContext CreateDbContext(string [] args)
        {
            var config = 
            ConfigurationManager.OpenMappedExeConfiguration(
                new ExeConfigurationFileMap { ExeConfigFilename = GetPersistenceConfigPath() },
                ConfigurationUserLevel.None);

            var connectionString = config.ConnectionStrings.ConnectionStrings["ShoppingCoreConstr"].ConnectionString;

            var optionsBuilder = new DbContextOptionsBuilder<ShoppingCoreDbContext>();

            optionsBuilder.UseSqlServer(connectionString);

            return new ShoppingCoreDbContext(optionsBuilder.Options);
        }

        private string GetPersistenceConfigPath()
        {
            var persistenceConfigPath = Convert.ToString(Directory.GetCurrentDirectory());
            persistenceConfigPath = persistenceConfigPath.Remove(persistenceConfigPath.IndexOf("ShoppingCore"));
            persistenceConfigPath += @"ShoppingCore\ShoppingCore.Persistence\bin\Debug\netcoreapp2.1\ShoppingCore.Persistence.dll.config";
            return persistenceConfigPath;
        }
    }
}
