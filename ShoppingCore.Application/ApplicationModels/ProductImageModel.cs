using ShoppingCore.Application.Interfaces;

namespace ShoppingCore.Application.ApplicationModels
{
    public class ProductImageModel : IAppModel
    {
        public string ImageUrl { get; set; }

        public int ProductID { get; set; }
    }
}