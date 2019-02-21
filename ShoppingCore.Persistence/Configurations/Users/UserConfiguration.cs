using ShoppingCore.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ShoppingCore.Provider.EfCore.Configurations.Users
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.UserID);

            builder.Property(u => u.UserName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Ignore(u => u.IsAutheticated);
        }
    }
}
