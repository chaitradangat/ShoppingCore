using ShoppingCore.Application.Interfaces;
using ShoppingCore.Domain.Interfaces;

namespace ShoppingCore.Application.ApplicationModels
{
    public class ProductImageModel : IAppModel
    {
        public int ProductImageID { get; set; }

        public string ImageUrl { get; set; }

        public int ProductID { get; set; }
    }
}