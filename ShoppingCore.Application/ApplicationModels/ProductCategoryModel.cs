using ShoppingCore.Application.Interfaces;

namespace ShoppingCore.Application.ApplicationModels
{
    public class ProductCategoryModel : IAppModel
    {
        public ProductModel ProductModel { get; set; }

        public CategoryModel CategoryModel { get; set; }
    }
}
