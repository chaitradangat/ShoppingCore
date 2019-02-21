using ShoppingCore.Application.Interfaces;
using ShoppingCore.Persistence.EfCore.Interfaces;

using ShoppingCore.Domain.Common;
using ShoppingCore.Domain.Customers;
using ShoppingCore.Domain.Products;
using ShoppingCore.Domain.Sellers;
using ShoppingCore.Domain.Users;

using ShoppingCore.Persistence.EfCore.Common;
using ShoppingCore.Persistence.EfCore.Customers;
using ShoppingCore.Persistence.EfCore.Products;
using ShoppingCore.Persistence.EfCore.Sellers;
using ShoppingCore.Persistence.EfCore.Users;


namespace ShoppingCore.Persistence.EfCore
{
    public class EfCorePersistence : IPersistence<IEntity>
    {
        #region -The Concrete Implementations of IRepository-
        //this logic needs to be improved.
        private UserRepository _users;

        private SellerRepository _sellers;

        private ProductRepository _products;

        private ProductImageRepository _productimages;

        private ProductCategoryRepository _productcategories;

        private CategoryRepository _categories;

        private CustomerRepository _customers;

        private AddressRepository _addresses;
        #endregion

        private readonly IEfcoreDatabaseService _efcoreDatabaseService;

        public IRepository<Address> Addresses => _addresses;

        public IRepository<Customer> Customers => _customers;

        public IRepository<Category> Categories => _categories;

        public IRepository<ProductCategory> ProductCategories => _productcategories;

        public IRepository<ProductImage> ProductImages => _productimages;

        public IRepository<Product> Products => _products;

        public IRepository<Seller> Sellers => _sellers;

        public IRepository<User> Users => _users;

        public EfCorePersistence(IEfcoreDatabaseService efcoreDatabaseService)
        {
            _efcoreDatabaseService = efcoreDatabaseService;

            #region -Initialize Concrete Implementations of IRepository-
            //The concrete implementations need to be initialized improve this logic
            _addresses = new AddressRepository(_efcoreDatabaseService);

            _customers = new CustomerRepository(_efcoreDatabaseService);

            _categories = new CategoryRepository(_efcoreDatabaseService);

            _productcategories = new ProductCategoryRepository(_efcoreDatabaseService);

            _productimages = new ProductImageRepository(_efcoreDatabaseService);

            _products = new ProductRepository(_efcoreDatabaseService);

            _sellers = new SellerRepository(_efcoreDatabaseService);

            _users = new UserRepository(_efcoreDatabaseService);
            #endregion
        }
    }
}