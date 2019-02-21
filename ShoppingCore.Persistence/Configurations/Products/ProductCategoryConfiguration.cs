using ShoppingCore.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShoppingCore.Persistence.Configurations.Products
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(pc => pc.ProductCategoryID);

            builder.HasOne(pc => pc.Product);

            builder.HasOne(pc => pc.Category);
        }
    }
}