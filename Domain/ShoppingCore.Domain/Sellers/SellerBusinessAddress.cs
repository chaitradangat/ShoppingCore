using ShoppingCore.Domain.Common;
using ShoppingCore.Domain.Interfaces;

namespace ShoppingCore.Domain.Sellers
{
    public class SellerBusinessAddress : IEntity
    {
        public int SellerBusinessAddressID { get; set; }

        public int SellerBusinessID { get; set; }

        public int AddressID { get; set; }

        public virtual SellerBusiness SellerBusiness { get; set; }

        public virtual Address Address { get; set; }
    }
}