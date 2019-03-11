using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingCore.Domain.Products;

namespace ShoppingCore.Provider.EfCore.Configurations.Products
{
    class ProductAddressConfiguration : IEntityTypeConfiguration<ProductAddress>
    {
        public void Configure(EntityTypeBuilder<ProductAddress> builder)
        {
            builder.HasKey(pa => pa.ProductAddressID);

            builder.HasOne(pa => pa.Address);
        }
    }
}
