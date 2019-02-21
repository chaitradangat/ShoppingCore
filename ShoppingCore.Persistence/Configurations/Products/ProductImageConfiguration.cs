using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingCore.Domain.Products;

namespace ShoppingCore.Provider.EfCore.Configurations.Products
{
    class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.HasKey(pi => pi.ProductImageID);

            builder.Property(pi => pi.ImageUrl).IsRequired();
        }
    }
}
