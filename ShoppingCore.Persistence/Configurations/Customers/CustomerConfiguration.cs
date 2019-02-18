using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ShoppingCore.Domain.Customers;
using ShoppingCore.Domain.Common;
using ShoppingCore.Domain.Users;


namespace ShoppingCore.Persistence.Configurations.Customers
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.CustomerID);

            builder.HasOne(c => c.User);

            builder.HasMany<Address>(a => a.Addresses)
                .WithOne(c => c.Customer);

        }
    }
}
