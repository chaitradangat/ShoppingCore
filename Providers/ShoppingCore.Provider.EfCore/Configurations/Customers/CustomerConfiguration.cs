using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ShoppingCore.Domain.Customers;
using ShoppingCore.Domain.Common;
using ShoppingCore.Domain.Users;


namespace ShoppingCore.Provider.EfCore.Configurations.Customers
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.CustomerID);

            builder.HasOne(c => c.User)
                   .WithOne(u => u.Customer)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Addresses)
                .WithOne(ca => ca.Customer)
                .HasForeignKey(ca => ca.CustomerID) //#todo:check which key to use here!
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
