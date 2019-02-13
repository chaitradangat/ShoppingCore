
namespace ShoppingCore.Domain.Interfaces
{
    public interface ICategory
    {
         int CategoryID { get; set; }

         int ProductID { get; set; }

         ICategory Category { get; set; }

         IProduct Product { get; set; }
    }
}