using ShoppingCore.Domain.Sellers;
using ShoppingCore.Domain.Users;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Microsoft.EntityFrameworkCore.SqlServer;

using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;

namespace ShoppingCore.Provider.EfCore.Configurations.Sellers
{
    public class SellerConfiguration : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            builder.HasKey(s => s.SellerID);

            builder.HasOne(s => s.User)
                   .WithOne(u => u.Seller)
                   .OnDelete(DeleteBehavior.Cascade);
                
            builder.HasMany(p => p.Products)
                .WithOne(s => s.Seller);
        }
    }
}
