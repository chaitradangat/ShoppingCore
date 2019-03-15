using ShoppingCore.Application.Interfaces;
using ShoppingCore.Domain.Interfaces;

namespace ShoppingCore.Application.ApplicationModels
{
    public class CategoryModel : IAppModel
    {
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public CategoryModel SubCategory { get; set; }
    }
}
