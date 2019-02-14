using ShoppingCore.Application.Interfaces;
using ShoppingCore.Domain.Common;
using ShoppingCore.Domain.Interfaces;

namespace ShoppingCore.Application.ApplicationModels
{
    public class ProductCategoryModel : IAppModel
    {
        public ProductModel ProductModel { get; set; }

        public CategoryModel CategoryModel { get; set; }

        public IEntity MorphAppModel()
        {
            throw new System.NotImplementedException();
        }
    }
}
