using ShoppingCore.Domain.Sellers;
using ShoppingCore.Domain.Users;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Microsoft.EntityFrameworkCore.SqlServer;

using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;

namespace ShoppingCore.Persistence.Configurations.Sellers
{
    public class SellerConfiguration : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            builder.HasKey(s => s.SellerID);

            builder.HasOne(s => s.User);
                
            builder.HasMany(p => p.Products)
                .WithOne(s => s.Seller);
        }
    }
}
