using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;



using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;



namespace ShoppingCore.Persistence
{
    class ShoppingCoreDbContextFactory : IDesignTimeDbContextFactory<ShoppingCoreDbContext>
    {
        public ShoppingCoreDbContext CreateDbContext(string [] args)
        {


            //below commented code is not working investigate why
            //var connectionString = ConfigurationManager.ConnectionStrings["ShoppingCoreDbContext"].ConnectionString; -- not working
            //var connectionString = ConfigurationManager.AppSettings["ShoppingCoreDbContext"]; -- not working

            var config = 
            ConfigurationManager.OpenMappedExeConfiguration(
                new ExeConfigurationFileMap { ExeConfigFilename = "App.config" }, 
                ConfigurationUserLevel.None);
            
            //var connectionString = config.AppSettings.Settings["ShoppingCoreDbContext"].Value; -- this works too! 

            var connectionString = config.ConnectionStrings.ConnectionStrings["ShoppingCoreConstr"].ConnectionString;


            var optionsBuilder = new DbContextOptionsBuilder<ShoppingCoreDbContext>();

            optionsBuilder.UseSqlServer(connectionString);

            return new ShoppingCoreDbContext(optionsBuilder.Options);
        }




    }
}
