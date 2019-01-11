﻿using System;
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

            var str = ConfigurationManager.ConnectionStrings["ShoppingCoreDbContext"].ConnectionString;

            var optionsBuilder = new DbContextOptionsBuilder<ShoppingCoreDbContext>();

            optionsBuilder.UseSqlServer("server=WORKSTATION-PC;database=ShoppingDB;uid=sa;pwd=sql;");

            return new ShoppingCoreDbContext(optionsBuilder.Options);
        }




    }
}
