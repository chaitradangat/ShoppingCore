using ShoppingCore.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingCore.Domain.Common;

namespace ShoppingCore.Provider.EfCore.Configurations.Products
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductID);

            builder.HasMany(p => p.ProductImages)
                .WithOne(p => p.Product);

            builder.HasOne(p => p.Seller)
                .WithMany(s => s.Products);

            builder.HasMany(p => p.ProductCategories)
                .WithOne(pc => pc.Product)
                .HasForeignKey(pc => pc.ProductID);

            builder.HasOne(p => p.Address);
        }
    }
}
