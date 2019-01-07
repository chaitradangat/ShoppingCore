using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;


namespace ShoppingCore.Persistence
{
    class ShoppingCoreDbContextFactory : IDesignTimeDbContextFactory<ShoppingCoreDbContext>
    {
        public ShoppingCoreDbContext CreateDbContext(string [] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ShoppingCoreDbContext>();

            optionsBuilder.UseSqlServer("server=WORKSTATION-PC;database=ShoppingDB;uid=sa;pwd=sql");

            return new ShoppingCoreDbContext(optionsBuilder.Options);
        }
    }
}
