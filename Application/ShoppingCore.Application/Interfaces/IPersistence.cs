using ShoppingCore.Domain.Interfaces;
using ShoppingCore.Domain.Customers;
using ShoppingCore.Domain.Products;
using ShoppingCore.Domain.Sellers;
using ShoppingCore.Domain.Users;

namespace ShoppingCore.Application.Interfaces
{
    /// <summary>
    /// This interface defines the Unit Of Work
    /// </summary>
    public interface IPersistence<T> where T:IEntity
    {
        IRepository<Address> Addresses { get; }

        IRepository<Customer> Customers { get; }

        IRepository<Category> Categories { get; }

        IRepository<ProductCategory> ProductCategories { get; }

        IRepository<ProductImage> ProductImages { get; }

        IRepository<Product> Products { get; }

        IRepository<Seller> Sellers { get; }

        IRepository<User> Users { get; }

        void Save();
    }
}