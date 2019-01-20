using ShoppingCore.Domain.Customers;
using ShoppingCore.Domain.Products;
using ShoppingCore.Domain.Sellers;
using ShoppingCore.Domain.Users;
using ShoppingCore.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace ShoppingCore.Application.Interfaces
{
    public interface IDatabaseService
    {
        DbSet<Address> Addresses { get; set; }

        DbSet<Customer> Customers { get; set; }

        DbSet<Product> Products { get; set; }

        DbSet<Category> Categories { get; set; }

        DbSet<ProductCategory> ProductCategories { get; set; }

        DbSet<Seller> Sellers { get; set; }

        DbSet<User> Users { get; set; }

        void Save();

    }
}
