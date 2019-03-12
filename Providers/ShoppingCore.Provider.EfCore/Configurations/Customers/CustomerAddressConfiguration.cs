using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ShoppingCore.Domain.Customers;

namespace ShoppingCore.Provider.EfCore.Configurations.Customers
{
    public class CustomerAddressConfiguration : IEntityTypeConfiguration<CustomerAddress>
    {
        public void Configure(EntityTypeBuilder<CustomerAddress> builder)
        {
            builder.HasKey(ca => ca.CustomerAddressID);

            builder.HasOne(ca => ca.Address);//#todo delete cascade to address table 
                //.WithOne(a=>a.CustomerAddress)
                //.OnDelete(DeleteBehavior.Cascade);
        }
    }
}
