using ShoppingCore.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingCore.Domain.Common;

namespace ShoppingCore.Persistence.Configurations.Customers
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.CustomerID);

            builder.HasMany<Address>(a => a.Addresses)
                .WithOne(c => c.Customer);

        }
    }
}
