using ShoppingCore.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Query;

using ShoppingCore.Domain.Users;
using ShoppingCore.Domain.Common;



namespace ShoppingCore.Persistence.Configurations
{
    public static class RelatedDomainLoader
    {
        public static IIncludableQueryable<Customer,List<Address>> LoadRelatedEntities(this DbSet<Customer> customers)
        {
            return customers.Include(c => c.User).Include(c => c.Addresses);
        }




    }
}
