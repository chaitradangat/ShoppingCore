using ShoppingCore.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingCore.Domain.Interfaces;

namespace ShoppingCore.Provider.EfCore.Configurations.Products
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductID);

            builder.HasMany(p => p.ProductImages)
                .WithOne(p => p.Product);

            builder.HasOne(p => p.Seller);
                

            builder.HasMany(p => p.ProductCategories)
                .WithOne(pc => pc.Product)
                .HasForeignKey(pc => pc.ProductID);

            builder.HasOne(p => p.ProductAddress)
                .WithOne(pa => pa.Product)
                .HasForeignKey<ProductAddress>(pa=>pa.ProductAddressID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
