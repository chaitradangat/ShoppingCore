using ShoppingCore.Domain.Interfaces;
using ShoppingCore.Domain.Customers;
using ShoppingCore.Domain.Products;
using ShoppingCore.Domain.Sellers;
using ShoppingCore.Domain.Users;

namespace ShoppingCore.Domain.XDomainFactory
{
    public class DomainFactory : IDomainFactory
    {
        public IEntity GetEntity<T>()
        {
            if (typeof(T) == typeof(IAddress))
            {
                return new Address();
            }
            else if (typeof(T) == typeof(ICategory))
            {
                return new Category();
            }
            else if (typeof(T) == typeof(ICustomer))
            {
                return new Customer();
            }
            else if (typeof(T) == typeof(IProduct))
            {
               return  new Product();
            }
            else if (typeof(T) == typeof(IProductCategory))
            {
                return new ProductCategory();
            }
            else if (typeof(T) == typeof(IProductImage))
            {
                return new ProductImage();
            }
            else if (typeof(T) == typeof(ISeller))
            {
                return new Seller();
            }
            else if (typeof(T) == typeof(IUser))
            {
                return new User();
            }
            else
            {
                return null;    
            }
        }
    }
}
