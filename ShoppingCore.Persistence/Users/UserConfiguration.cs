﻿using System;
using System.Collections.Generic;
using System.Text;

using ShoppingCore.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace ShoppingCore.Persistence.Users
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.UserId);

            builder.Property(u => u.UserName)
                   .IsRequired()
                   .HasMaxLength(50);


        }
    }
}
