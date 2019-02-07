using ShoppingCore.Application.Interfaces;

namespace ShoppingCore.Application.ApplicationModels
{
    public class CategoryModel : IAppModel
    {
        public string CategoryName { get; set; }

        public CategoryModel SubCategory { get; set; }
    }
}
